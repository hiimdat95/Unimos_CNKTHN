// Author: TrungVK
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Collections;

namespace TruongViet.UnimOs.wsBusiness
{
    internal class BasicNode : Node
    {
        // Fields
        public IConvertible Value;

        // Methods
        public BasicNode(IConvertible Val)
        {
            this.Value = Val;
        }

        public override IConvertible GetValue()
        {
            return this.Value;
        }



        public override double GetValueAsDouble()
        {
            if (this.Value is double)
            {
                return (double)this.Value;
            }
            if (this.Value is string)
            {
                return double.Parse((string)this.Value, CultureInfo.InvariantCulture.NumberFormat);
            }
            return Convert.ToDouble(this.Value);
        }

        public override string GetValueAsString()
        {
            if (this.Value is string)
            {
                return (string)this.Value;
            }
            return Convert.ToString(this.Value);
        }

        public override bool IsUsed(object Addr)
        {
            return false;
        }

        public virtual bool IsUsed(string Name)
        {
            return false;
        }

        public override void Optimize()
        {
        }
    }

    public interface IFunction
    {
        // Methods
        int GetNumberOfParams();
        IConvertible Run(IParameter[] p);
    }

    public interface IParameter
    {
        // Methods
        IConvertible GetValue();
        double GetValueAsDouble();
        string GetValueAsString();
    }

    public class MathParser : StandardLib
    {
        // Fields
        private static char[] FANCY_PARANTHESIS = new char[] { '[', '{', '}', ']' };
        protected TwoParameterFunc m_AddOp = StandardLib.add_;
        protected TwoParameterFunc m_AndOp = StandardLib.andWithStr_;
        protected CultureInfo m_CultureInfo = CultureInfo.CurrentCulture;
        private static Translator m_DefaultTranslator;
        protected bool m_Dirty = true;
        protected string m_Expression = "";
        protected Hashtable m_Functions = new Hashtable();
        private Node m_Node = null;
        protected bool m_OptimizationOn = false;
        protected STR_CONCAT_OP m_StrConcatOperator;
        protected bool m_StringLiteralsAllowed = true;
        private Translator m_translate = GetDefaultTranslator();
        protected Hashtable m_Variables = new Hashtable();

        // Methods


        public MathParser()
        {
            this.CreateDefaultFuncs();
            this.CreateDefaultVars();
        }

        protected static int CheckBrackets(string formula)
        {
            int num2 = 0;
            int length = formula.Length;
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                char ch = formula[i];
                if (ch == '"')
                {
                    flag = !flag;
                    continue;
                }
                if (!flag)
                {
                    switch (ch)
                    {
                        case '(':
                            num2++;
                            break;

                        case ')':
                            num2--;
                            break;
                    }
                    if (num2 < 0)
                    {
                        return i;
                    }
                }
            }
            if (num2 != 0)
            {
                return length;
            }
            return -1;
        }

        private static bool CheckEscapes(string formula)
        {
            int length = formula.Length;
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                char ch = formula[i];
                if (ch == '"')
                {
                    if (flag)
                    {
                        return false;
                    }
                    i++;
                    if ((i >= length) || (formula[i] != '"'))
                    {
                        return false;
                    }
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            return true;
        }

        public void CreateConstant(string varName, double newVal)
        {
            this.SetVariable(varName, newVal, true, null);
        }

        public void CreateConstant(string varName, string newVal)
        {
            this.SetVariable(varName, newVal, true, null);
        }

        public void CreateDefaultFuncs()
        {
            this.CreateFunc("SQR", StandardLib.square_);
            this.CreateFunc("SIN", StandardLib.sin_);
            this.CreateFunc("COS", StandardLib.cos_);
            this.CreateFunc("ATAN", StandardLib.arctan_);
            this.CreateFunc("SINH", StandardLib.sinh_);
            this.CreateFunc("COSH", StandardLib.cosh_);
            this.CreateFunc("COTAN", StandardLib.cotan_);
            this.CreateFunc("TAN", StandardLib.tan_);
            this.CreateFunc("EXP", StandardLib.exp_);
            this.CreateFunc("LN", StandardLib.ln_);
            this.CreateFunc("LOG", StandardLib.log10_);
            this.CreateFunc("SQRT", StandardLib.sqrt_);
            this.CreateFunc("ABS", StandardLib.abs_);
            this.CreateFunc("SIGN", StandardLib.sign_);
            this.CreateFunc("TRUNC", StandardLib.trunc_);
            this.CreateFunc("CEIL", StandardLib.ceil_);
            this.CreateFunc("FLOOR", StandardLib.floor_);
            this.CreateFunc("RND", StandardLib.rnd_);
            this.CreateFunc("VAL", StandardLib.double_);
            this.CreateFunc("INTPOW", StandardLib.intpower_);
            this.CreateFunc("POW", StandardLib.power_);
            this.CreateFunc("LOGN", StandardLib.logN_);
            this.CreateFunc("MIN", StandardLib.min_);
            this.CreateFunc("MAX", StandardLib.max_);
            this.CreateFunc("MOD", StandardLib.modulo_);
            this.CreateFunc("IF", StandardLib.if_);
            this.CreateFunc("STRLEN", StandardLib.strlen_);
            this.CreateFunc("STR", StandardLib.str_);
            this.CreateFunc("SUBSTR", StandardLib.substr_);
            this.CreateFunc("CONCAT", StandardLib.concat_);
            this.CreateFunc("TRIM", StandardLib.trim_);
            this.CreateFunc("RTRIM", StandardLib.rtrim_);
            this.CreateFunc("LTRIM", StandardLib.ltrim_);
            this.CreateFunc("CHR", StandardLib.chr_);
            this.CreateFunc("SUM", StandardLib.sum_);
        }

        public void CreateDefaultVars()
        {
            try
            {
                this.CreateConstant("PI", (double)3.14159265358979);
                this.CreateVar("X", (double)0.0, null);
                this.CreateVar("Y", (double)0.0, null);
            }
            catch (Exception)
            {
            }
        }

        public void CreateFunc(string newFuncName, IFunction funcAddr)
        {
            if (newFuncName == null)
            {
                throw new ArgumentNullException("Function name cannot be null.");
            }
            if (funcAddr == null)
            {
                throw new ArgumentNullException("Function implementation cannot be null.");
            }
            string name = newFuncName.ToUpper();
            if (!this.IsValidName(name))
            {
                throw new Exception(this.m_translate.getMessage("NtFncNm", newFuncName));
            }
            if (this.IsFunction(name))
            {
                throw new Exception(this.m_translate.getMessage("FncExst", newFuncName));
            }
            if (funcAddr.GetNumberOfParams() < -1)
            {
                throw new Exception(this.m_translate.getMessage("WrngNPrms", newFuncName, Convert.ToString(funcAddr.GetNumberOfParams())));
            }
            this.m_Functions.Add(name, funcAddr);
            this.m_Dirty = true;
        }

        public void CreateOneParamFunc(string newFuncName, OneParamFunc funcAddr)
        {
            this.CreateFunc(newFuncName, new OneParamFuncAdapter(funcAddr));
        }

        internal Node CreateParseTree(string expToParse)
        {
            expToParse = expToParse.Trim();
            if (expToParse.Length != 0)
            {
                double num;
                IFunction function;
                string str3;
                string str4;
                string str5;
                string[] strArray;
                string formula = RemoveOuterBrackets(expToParse);
                if (formula.Length != expToParse.Length)
                {
                    formula = formula.Trim();
                    if (formula.Length == 0)
                    {
                        return null;
                    }
                }
                if (IsValiddouble(formula, out num))
                {
                    return new BasicNode(num);
                }
                if (this.m_StringLiteralsAllowed)
                {
                    string stringLiteral = GetStringLiteral(formula);
                    if (stringLiteral != null)
                    {
                        return new BasicNode(stringLiteral);
                    }
                }
                Node node = this.CreateVarNode(formula);
                if (node != null)
                {
                    return node;
                }
                Node node2 = null;
                Node node3 = null;
                int currChar = FindLastOper(formula);
                if ((currChar <= 0) && this.IsOneParamFunc(formula, out function, out str3, currChar))
                {
                    node2 = this.CreateParseTree(str3);
                    if (node2 == null)
                    {
                        throw new ParserException(this.m_translate.getMessage("ExpNtVld", str3, formula), str3, formula);
                    }
                    if (function != null)
                    {
                        return new NParamNode(new Node[] { node2 }, function);
                    }
                }
                if (this.IsTwoParamFunc(formula, out function, out str4, out str5, currChar))
                {
                    node2 = this.CreateParseTree(str4);
                    if (node2 == null)
                    {
                        throw new ParserException(this.m_translate.getMessage("ExpNtVld", str4, formula), str4, formula);
                    }
                    node3 = this.CreateParseTree(str5);
                    if (node3 == null)
                    {
                        throw new ParserException(this.m_translate.getMessage("ExpNtVld", str5, formula), str5, formula);
                    }
                    if (function != null)
                    {
                        return new NParamNode(new Node[] { node2, node3 }, function);
                    }
                }
                if (this.IsNParamFunc(formula, out function, out strArray, currChar))
                {
                    if (strArray == null)
                    {
                        throw new ParserException(this.m_translate.getMessage("InvNPrm", formula), formula, formula);
                    }
                    int length = strArray.Length;
                    Node[] n = new Node[length];
                    for (int i = 0; i < length; i++)
                    {
                        node2 = this.CreateParseTree(strArray[i]);
                        if (node2 == null)
                        {
                            throw new ParserException(this.m_translate.getMessage("ExpNtVld", strArray[i], formula), strArray[i], formula);
                        }
                        n[i] = node2;
                    }
                    if (function != null)
                    {
                        return new NParamNode(n, function);
                    }
                }
            }
            return null;
        }

        public void CreateTwoParamFunc(string newFuncName, TwoParamFunc funcAddr)
        {
            this.CreateFunc(newFuncName, new TwoParamFuncAdapter(funcAddr));
        }

        public void CreateVar(string varName, double varValue, VariableDelegate valueProvider)
        {
            this.SetVariable(varName, varValue, valueProvider);
        }

        public void CreateVar(string varName, string varValue, VariableDelegate valueProvider)
        {
            this.SetVariable(varName, varValue, valueProvider);
        }

        protected virtual Node CreateVarNode(string varName)
        {
            Variable variable = (Variable)this.m_Variables[varName];
            if (variable == null)
            {
                return null;
            }
            if (variable.IsConstant)
            {
                return new BasicNode(variable.GetRuntimeValue());
            }
            return new VarNode(variable);
        }

        public void DeleteAllFuncs()
        {
            this.m_Functions.Clear();
            this.m_Dirty = true;
        }

        public void DeleteAllVars()
        {
            this.m_Variables.Clear();
            this.m_Dirty = true;
        }

        public void DeleteFunc(string funcName)
        {
            if (funcName == null)
            {
                throw new ArgumentNullException("Function name cannot be null.");
            }
            string key = funcName.ToUpper();
            this.m_Functions.Remove(key);
            this.m_Dirty = true;
        }

        public void DeleteVar(string varName)
        {
            if (varName == null)
            {
                throw new ArgumentNullException("Variable name cannot be null.");
            }
            string key = varName.ToUpper();
            this.m_Variables.Remove(key);
            this.m_Dirty = true;
        }

        public IConvertible Evaluate()
        {
            if (this.m_Dirty)
            {
                this.Parse();
            }
            return this.m_Node.GetValue();
        }

        private static int FindLastOper(string formula)
        {
            int num = 13;
            int num2 = 0;
            int num3 = -1;
            int length = formula.Length;
            int num5 = 0;
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                char ch = formula[i];
                if (ch == '"')
                {
                    flag = !flag;
                }
                else if (!flag)
                {
                    if (num5 > 2)
                    {
                        return -1;
                    }
                    char ch3 = ch;
                    if (ch3 <= '>')
                    {
                        switch (ch3)
                        {
                            case ' ':
                                {
                                    continue;
                                }
                            case '!':
                                goto Label_0124;

                            case '"':
                            case '#':
                            case '$':
                            case '\'':
                            case ',':
                            case '.':
                                goto Label_031C;

                            case '%':
                                goto Label_0213;

                            case '&':
                                goto Label_0107;

                            case '(':
                                {
                                    num2++;
                                    num5 = 0;
                                    continue;
                                }
                            case ')':
                                {
                                    num2--;
                                    num5 = 0;
                                    continue;
                                }
                            case '*':
                                goto Label_0251;

                            case '+':
                                goto Label_01F6;

                            case '-':
                                goto Label_01D9;

                            case '/':
                                goto Label_0232;

                            case '<':
                                goto Label_01BC;

                            case '=':
                                goto Label_0141;

                            case '>':
                                goto Label_0188;
                        }
                        goto Label_031C;
                    }
                    switch (ch3)
                    {
                        case 'E':
                            goto Label_028F;

                        case '^':
                            {
                                if (((num2 <= 0) && (num5 <= 0)) && (num >= 12))
                                {
                                    num = 12;
                                    num3 = i;
                                }
                                num5++;
                                continue;
                            }
                    }
                    if (ch3 != '|')
                    {
                        goto Label_031C;
                    }
                    if (((num2 <= 0) && (num5 <= 0)) && (num >= 1))
                    {
                        num = 1;
                        num3 = i;
                    }
                    num5++;
                }
                continue;
            Label_0107:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 2))
                {
                    num = 2;
                    num3 = i;
                }
                num5++;
                continue;
            Label_0124:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 3))
                {
                    num = 3;
                    num3 = i;
                }
                num5++;
                continue;
            Label_0141:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 4))
                {
                    num = 4;
                    num3 = i;
                }
                if (num5 > 0)
                {
                    int num7 = i - num5;
                    if ((formula[num7] == '<') || (formula[num7] == '>'))
                    {
                        continue;
                    }
                }
                num5++;
                continue;
            Label_0188:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 5))
                {
                    num = 5;
                    num3 = i;
                }
                if ((num5 <= 0) || (formula[i - num5] != '<'))
                {
                    num5++;
                }
                continue;
            Label_01BC:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 5))
                {
                    num = 5;
                    num3 = i;
                }
                num5++;
                continue;
            Label_01D9:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 7))
                {
                    num = 7;
                    num3 = i;
                }
                num5++;
                continue;
            Label_01F6:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 7))
                {
                    num = 7;
                    num3 = i;
                }
                num5++;
                continue;
            Label_0213:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 9))
                {
                    num = 9;
                    num3 = i;
                }
                num5++;
                continue;
            Label_0232:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 9))
                {
                    num = 9;
                    num3 = i;
                }
                num5++;
                continue;
            Label_0251:
                if (((num2 <= 0) && (num5 <= 0)) && (num >= 9))
                {
                    num = 9;
                    num3 = i;
                }
                num5++;
                continue;
            Label_028F:
                if ((i > 0) && (num5 == 0))
                {
                    char ch2 = formula[i - 1];
                    if ((ch2 < '0') || (ch2 > '9'))
                    {
                        continue;
                    }
                    int num8 = i;
                    while (num8 > 0)
                    {
                        num8--;
                        ch2 = formula[num8];
                        if ((ch2 != '.') && ((ch2 < '0') || (ch2 > '9')))
                        {
                            if ((ch2 == '_') || ((ch2 >= 'A') && (ch2 <= 'Z')))
                            {
                                num5 = 0;
                            }
                            else
                            {
                                num5++;
                            }
                            break;
                        }
                    }
                    if (((num8 == 0) && (ch2 >= '0')) && (ch2 <= '9'))
                    {
                        num5++;
                    }
                    continue;
                }
                num5 = 0;
                continue;
            Label_031C:
                num5 = 0;
            }
            return num3;
        }

        public void FreeParseTree()
        {
            this.m_Node = null;
            this.m_Dirty = true;
        }

        private static Translator GetDefaultTranslator()
        {
            if (m_DefaultTranslator == null)
            {
                Hashtable strings = new Hashtable();
                strings.Add("ExpEmpty", "Expression is empty.");
                strings.Add("VarNtExst", "Variable {0} does not exist.");
                strings.Add("VarNtDbl", "Variable {0} is not numeric.");
                strings.Add("VarNtStr", "Variable {0} is not a string.");
                strings.Add("VarNtDblStr", "Variable {0} should be a Double or a String. It is {1}.");
                strings.Add("VarExt", "Variable {0} already exists.");
                strings.Add("NtVarNm", "{0} is not a valid variable name.");
                strings.Add("SntxErr", "Syntax error in expression {0}");
                strings.Add("NtFncNm", "{0} is not a valid function name.");
                strings.Add("FncExst", "Function {0} already exists.");
                strings.Add("WrngNPrms", "Function {0} must accept at least 0 parameters not {1}.");
                strings.Add("ExpNtVld", "Sub expression <{0}> in <{1}> is not valid.");
                strings.Add("InvNPrm", "Invaid number of parameters in <{0}>.");
                strings.Add("BrcktMis", "Bracket mismatch in expression <{0}> at index {1}.");
                strings.Add("MisBrckt", "Missing bracket \")\" in expression <{0}>.");
                m_DefaultTranslator = new Translator(strings);
            }
            return m_DefaultTranslator;
        }

        public string[] GetFunctions()
        {
            string[] strArray;
            lock (this.m_Functions)
            {
                strArray = new string[this.m_Functions.Count];
                int num2 = 0;
                IEnumerator enumerator = this.m_Functions.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    strArray[num2++] = (string)enumerator.Current;
                }
            }
            return (string[])new Sort(this.m_CultureInfo).sort(strArray);
        }

        private static string GetStringLiteral(string formula)
        {
            if (((formula.Length > 1) && (formula[0] == '"')) && (formula[formula.Length - 1] == '"'))
            {
                string str = formula.Substring(1, formula.Length - 2);
                if (CheckEscapes(str))
                {
                    return StrUtil.Replace(str, "\"\"", "\"");
                }
            }
            return null;
        }

        public Hashtable GetTranslationStrings()
        {
            return this.m_translate.res;
        }

        public IConvertible GetVariable(string varName)
        {
            if (varName == null)
            {
                throw new ArgumentNullException("Variable name cannot be null.");
            }
            string str = varName.ToUpper();
            Variable variable = (Variable)this.m_Variables[str];
            if (variable == null)
            {
                throw new Exception(this.m_translate.getMessage("VarNtExst", varName));
            }
            return variable.GetRuntimeValue();
        }

        public string[] GetVariables()
        {
            string[] strArray;
            lock (this.m_Variables)
            {
                strArray = new string[this.m_Variables.Count];
                int num = 0;
                IEnumerator enumerator = this.m_Variables.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    strArray[num++] = (string)enumerator.Current;
                }
            }
            return (string[])new Sort(this.m_CultureInfo).sort(strArray);
        }

        public bool IsConstant(string constName)
        {
            if (constName == null)
            {
                throw new ArgumentNullException("Constant name cannot be null.");
            }
            constName = constName.ToUpper();
            Variable variable = (Variable)this.m_Variables[constName];
            if (variable == null)
            {
                return false;
            }
            return variable.IsConstant;
        }

        public bool IsFunction(string funcName)
        {
            if (funcName == null)
            {
                throw new ArgumentNullException("Function name cannot be null.");
            }
            funcName = funcName.ToUpper();
            return this.m_Functions.ContainsKey(funcName);
        }

        public bool IsFunctionUsed(string funcName)
        {
            if (this.m_Dirty)
            {
                this.Parse();
            }
            funcName = funcName.ToUpper();
            IFunction addr = (IFunction)this.m_Functions[funcName];
            return ((addr != null) && this.m_Node.IsUsed(addr));
        }

        private bool IsNParamFunc(string formula, out IFunction funcAddr, out string[] parms, int CurrChar)
        {
            funcAddr = null;
            parms = null;
            int length = formula.Length;
            StringBuilder builder = new StringBuilder();
            if (formula[length - 1] == ')')
            {
                int index = 0;
                while (this.IsValidChar(index, formula[index]))
                {
                    builder.Append(formula[index]);
                    index++;
                }
                while (formula[index] == ' ')
                {
                    index++;
                }
                if ((formula[index] == '(') && (index < (length - 1)))
                {
                    funcAddr = (IFunction)this.m_Functions[builder.ToString()];
                    if (funcAddr != null)
                    {
                        int num2;
                        int num3;
                        int numberOfParams = funcAddr.GetNumberOfParams();
                        if (numberOfParams <= -1)
                        {
                            ArrayList list = new ArrayList();
                            num3 = index + 1;
                            num2 = 1;
                            bool flag2 = false;
                            while (index <= ((length - 1) - 1))
                            {
                                index++;
                                switch (formula[index])
                                {
                                    case '(':
                                        if (!flag2)
                                        {
                                            num2++;
                                        }
                                        break;

                                    case ')':
                                        if (!flag2)
                                        {
                                            num2--;
                                        }
                                        break;

                                    case ',':
                                        if ((!flag2 && (1 == num2)) && (index < (length - 2)))
                                        {
                                            list.Add(formula.Substring(num3, index - num3));
                                            num3 = index + 1;
                                        }
                                        break;

                                    case '"':
                                        flag2 = !flag2;
                                        break;
                                }
                            }
                            string str = formula.Substring(num3, (length - 1) - num3).Trim();
                            if (str.Length > 0)
                            {
                                list.Add(str);
                            }
                            parms = (string[])list.ToArray(typeof(string));
                            return true;
                        }
                        parms = new string[numberOfParams];
                        if ((numberOfParams == 0) && (formula[index + 1] == ')'))
                        {
                            return true;
                        }
                        num3 = index + 1;
                        num2 = 1;
                        int num6 = 0;
                        bool flag = false;
                        while (index <= ((length - 1) - 1))
                        {
                            index++;
                            switch (formula[index])
                            {
                                case '(':
                                    {
                                        if (!flag)
                                        {
                                            num2++;
                                        }
                                        continue;
                                    }
                                case ')':
                                    {
                                        if (!flag)
                                        {
                                            num2--;
                                        }
                                        continue;
                                    }
                                case '*':
                                case '+':
                                    {
                                        continue;
                                    }
                                case ',':
                                    if ((flag || (1 != num2)) || (index >= (length - 2)))
                                    {
                                        continue;
                                    }
                                    if ((numberOfParams <= -1) || (num6 < numberOfParams))
                                    {
                                        break;
                                    }
                                    return false;

                                case '"':
                                    {
                                        flag = !flag;
                                        continue;
                                    }
                                default:
                                    {
                                        continue;
                                    }
                            }
                            parms[num6++] = formula.Substring(num3, index - num3);
                            if (num6 == (numberOfParams - 1))
                            {
                                parms[num6] = formula.Substring(index + 1, (length - 1) - (index + 1));
                                return true;
                            }
                            num3 = index + 1;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsOneParamFunc(string formula, out IFunction funcAddr, out string param, int CurrChar)
        {
            funcAddr = null;
            param = null;
            int length = formula.Length;
            if (CurrChar != 0)
            {
                if (formula[length - 1] == ')')
                {
                    int index = 0;
                    StringBuilder builder = new StringBuilder();
                    while (this.IsValidChar(index, formula[index]))
                    {
                        builder.Append(formula[index]);
                        index++;
                    }
                    while (formula[index] == ' ')
                    {
                        index++;
                    }
                    if ((formula[index] == '(') && (index < (length - 2)))
                    {
                        IFunction function = (IFunction)this.m_Functions[builder.ToString()];
                        if ((function != null) && (function.GetNumberOfParams() == 1))
                        {
                            funcAddr = function;
                            int startIndex = index + 1;
                            param = formula.Substring(startIndex, (length - 1) - startIndex);
                            return true;
                        }
                    }
                }
                return false;
            }
            param = formula.Substring(1);
            if (param.Length > 0)
            {
                switch (formula[CurrChar])
                {
                    case '+':
                        funcAddr = StandardLib.unaryadd_;
                        goto Label_006B;

                    case '-':
                        funcAddr = StandardLib.negate_;
                        goto Label_006B;

                    case '!':
                        funcAddr = StandardLib.not_;
                        goto Label_006B;
                }
            }
            return false;
        Label_006B:
            return true;
        }

        private bool IsTwoParamFunc(string formula, out IFunction funcAddr, out string paramLeft, out string paramRight, int CurrChar)
        {
            funcAddr = null;
            paramLeft = null;
            paramRight = null;
            int length = formula.Length;
            if (CurrChar <= 0)
            {
                StringBuilder builder = new StringBuilder();
                if (formula[length - 1] == ')')
                {
                    int index = 0;
                    while (this.IsValidChar(index, formula[index]))
                    {
                        builder.Append(formula[index]);
                        index++;
                    }
                    while (formula[index] == ' ')
                    {
                        index++;
                    }
                    if ((formula[index] == '(') && (index < (length - 1)))
                    {
                        IFunction function = (IFunction)this.m_Functions[builder.ToString()];
                        if ((function != null) && (function.GetNumberOfParams() == 2))
                        {
                            funcAddr = function;
                            int startIndex = index + 1;
                            int num2 = 1;
                            bool flag = false;
                            while (index <= ((length - 1) - 1))
                            {
                                index++;
                                switch (formula[index])
                                {
                                    case '(':
                                        if (!flag)
                                        {
                                            num2++;
                                        }
                                        break;

                                    case ')':
                                        if (!flag)
                                        {
                                            num2--;
                                        }
                                        break;

                                    case ',':
                                        if ((flag || (1 != num2)) || (index >= (length - 2)))
                                        {
                                            break;
                                        }
                                        paramLeft = formula.Substring(startIndex, index - startIndex);
                                        paramRight = formula.Substring(index + 1, (length - 1) - (index + 1));
                                        return true;

                                    case '"':
                                        flag = !flag;
                                        break;
                                }
                            }
                        }
                    }
                }
                return false;
            }
            if (CurrChar > (length - 2))
            {
                return false;
            }
            char ch = formula[CurrChar];
            if (ch != '<')
            {
                if (ch == '>')
                {
                    char ch3 = formula[CurrChar + 1];
                    if (ch3 == '=')
                    {
                        funcAddr = StandardLib.gtequals_;
                        paramLeft = formula.Substring(0, CurrChar);
                        paramRight = formula.Substring(CurrChar + 2);
                    }
                    else
                    {
                        funcAddr = StandardLib.greater_;
                        paramLeft = formula.Substring(0, CurrChar);
                        paramRight = formula.Substring(CurrChar + 1);
                    }
                    if (paramLeft.Length <= 0)
                    {
                        return false;
                    }
                    if (paramRight.Length <= 0)
                    {
                        return false;
                    }
                    return true;
                }
                paramLeft = formula.Substring(0, CurrChar);
                if (paramLeft.Length <= 0)
                {
                    return false;
                }
                paramRight = formula.Substring(CurrChar + 1);
                if (paramRight.Length <= 0)
                {
                    return false;
                }
                switch (formula[CurrChar])
                {
                    case '^':
                        funcAddr = StandardLib.power_;
                        goto Label_0234;

                    case '|':
                        funcAddr = StandardLib.or_;
                        goto Label_0234;

                    case '%':
                        funcAddr = StandardLib.intdiv_;
                        goto Label_0234;

                    case '&':
                        funcAddr = this.m_AndOp;
                        goto Label_0234;

                    case '\'':
                    case '(':
                    case ')':
                    case ',':
                    case '.':
                        goto Label_0234;

                    case '*':
                        funcAddr = StandardLib.multiply_;
                        goto Label_0234;

                    case '+':
                        funcAddr = this.m_AddOp;
                        goto Label_0234;

                    case '-':
                        funcAddr = StandardLib.subtract_;
                        goto Label_0234;

                    case '/':
                        funcAddr = StandardLib.divide_;
                        goto Label_0234;

                    case '<':
                        funcAddr = StandardLib.less_;
                        goto Label_0234;

                    case '=':
                        funcAddr = StandardLib.equals_;
                        goto Label_0234;

                    case '>':
                        funcAddr = StandardLib.greater_;
                        goto Label_0234;
                }
            }
            else
            {
                switch (formula[CurrChar + 1])
                {
                    case '>':
                        funcAddr = StandardLib.notequals_;
                        paramLeft = formula.Substring(0, CurrChar);
                        paramRight = formula.Substring(CurrChar + 2);
                        break;

                    case '=':
                        funcAddr = StandardLib.lsequals_;
                        paramLeft = formula.Substring(0, CurrChar);
                        paramRight = formula.Substring(CurrChar + 2);
                        break;

                    default:
                        funcAddr = StandardLib.less_;
                        paramLeft = formula.Substring(0, CurrChar);
                        paramRight = formula.Substring(CurrChar + 1);
                        break;
                }
                if (paramLeft.Length <= 0)
                {
                    return false;
                }
                if (paramRight.Length <= 0)
                {
                    return false;
                }
                return true;
            }
        Label_0234:
            return true;
        }

        private bool IsValidChar(int index, char c)
        {
            // không cần kiểm tra index =0 vì người dùng vẫn được phép nhập mã thành phần điểm là số (ví dụ: 1KT)
            //if (index == 0)
            //{
            //  return (((c >= 'A') && (c <= 'Z')) || (c == '_'));
            //}
            return (((c >= '0') && (c <= 'Z')) || (c == '_'));
        }

        protected static bool IsValiddouble(string formula, out double dblVal)
        {
            dblVal = 0.0;
            try
            {
                if ((formula.Length > 1) && (((formula[0] == '0') && (formula.IndexOf('.') != 1)) || (formula.IndexOf(',') != -1)))
                {
                    return false;
                }
                if (!double.TryParse(formula, NumberStyles.Float, (IFormatProvider)CultureInfo.InvariantCulture.NumberFormat, out dblVal))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool IsValidName(string name)
        {
            int length = name.Length;
            for (int i = 0; i < length; i++)
            {
                if (!this.IsValidChar(i, name[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsVariable(string varName)
        {
            if (varName == null)
            {
                throw new ArgumentNullException("Variable name cannot be null.");
            }
            varName = varName.ToUpper();
            return this.m_Variables.ContainsKey(varName);
        }

        public bool IsVariableUsed(string varName)
        {
            if (varName == null)
            {
                throw new ArgumentNullException("Variable name cannot be null.");
            }
            if (this.m_Dirty)
            {
                this.Parse();
            }
            varName = varName.ToUpper();
            object addr = this.m_Variables[varName];
            return ((addr != null) && this.m_Node.IsUsed(addr));
        }

        public void Optimize()
        {
            this.m_Node = OptimizeNode(this.m_Node);
        }

        internal static Node OptimizeNode(Node aNode)
        {
            aNode.Optimize();
            if (!(aNode is NParamNode))
            {
                return aNode;
            }
            NParamNode node = (NParamNode)aNode;
            Node[] nodes = node.nodes;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (!(nodes[i] is BasicNode))
                {
                    return aNode;
                }
            }
            return new BasicNode(node.GetValue());
        }

        public double Round(double SoLamTron, int SoSauDauPhay, bool LamTronTang)
        {
            double KetQua;
            string tmp = SoLamTron.ToString();
            if (LamTronTang == true)
            {
                KetQua = Math.Round(SoLamTron, SoSauDauPhay, MidpointRounding.AwayFromZero);
            }
            else
            {
                if (SoSauDauPhay < tmp.Length - 2)
                {
                    KetQua = double.Parse(tmp.Substring(0, 2 + SoSauDauPhay));
                }
                else
                {
                    KetQua = SoLamTron;
                }
            }
            return KetQua;
        }


        public void Parse()
        {
            //DateTime now = DateTime.Now;
            //DateTime time2 = DateTime.Parse("08/15/2009", CultureInfo.InvariantCulture);
            //if (now.CompareTo(time2) > 0)
            //{
            //    throw new Exception("Trial period has ended.");
            //}
            if ((this.m_Expression == null) || (this.m_Expression.Length <= 0))
            {
                this.m_Node = null;
                throw new Exception(this.m_translate.getMessage("ExpEmpty"));
            }
            char[] c = this.m_Expression.ToCharArray();
            this.UpperCase(c);
            int length = c.Length;
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                if (c[i] == '"')
                {
                    flag = !flag;
                }
                if (!flag)
                {
                    if ((c[i] == '[') || (c[i] == '{'))
                    {
                        c[i] = '(';
                    }
                    else if ((c[i] == ']') || (c[i] == '}'))
                    {
                        c[i] = ')';
                    }
                }
            }
            string formula = new string(c);
            int num3 = CheckBrackets(formula);
            if ((num3 > -1) && (num3 < formula.Length))
            {
                throw new ParserException(this.m_translate.getMessage("BrcktMis", formula, Convert.ToString(num3)), formula.Substring(num3), formula);
            }
            if (num3 == formula.Length)
            {
                throw new ParserException(this.m_translate.getMessage("MisBrckt", formula), formula, formula);
            }
            this.m_Node = this.CreateParseTree(formula);
            if (this.m_Node == null)
            {
                throw new ParserException(this.m_translate.getMessage("ExpNtVld", formula, formula), formula, formula);
            }
            if (this.m_OptimizationOn)
            {
                this.Optimize();
            }
            this.m_Dirty = false;
        }

        protected static string RemoveOuterBrackets(string formula)
        {
            string str = formula;
            for (int i = str.Length; ((i > 2) && (str[0] == '(')) && (str[i - 1] == ')'); i = str.Length)
            {
                str = str.Substring(1, str.Length - 2).Trim();
                if (CheckBrackets(str) == -1)
                {
                    formula = str;
                }
            }
            return formula;
        }

        private string RemoveSpacesExceptLiterals(string s)
        {
            if (s.IndexOf(' ') == -1)
            {
                return s;
            }
            int length = s.Length;
            bool flag = false;
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                if (ch == '"')
                {
                    flag = !flag;
                    builder.Append(ch);
                }
                else if (!flag)
                {
                    if (ch != ' ')
                    {
                        builder.Append(ch);
                    }
                }
                else
                {
                    builder.Append(ch);
                }
            }
            return builder.ToString();
        }

        public void SetTranslationStrings(Hashtable strings)
        {
            this.m_translate.res = strings;
        }

        public void SetVariable(string varName, double newVal, VariableDelegate valueProvider)
        {
            this.SetVariable(varName, newVal, false, valueProvider);
        }

        public void SetVariable(string varName, string newVal, VariableDelegate valueProvider)
        {
            this.SetVariable(varName, newVal, false, valueProvider);
        }

        private void SetVariable(string varName, IConvertible newVal, bool isConst, VariableDelegate valueProvider)
        {
            if (varName == null)
            {
                throw new ArgumentNullException("Variable name cannot be null.");
            }
            if (!(newVal is double) && !(newVal is string))
            {
                newVal = Convert.ToDouble(newVal);
            }
            string name = varName.ToUpper();
            Variable variable = (Variable)this.m_Variables[name];
            if (variable != null)
            {
                if (variable.IsConstant)
                {
                    throw new Exception(this.m_translate.getMessage("CnstVal", varName));
                }
                variable.Value = newVal;
            }
            else
            {
                if (!this.IsValidName(name))
                {
                    throw new Exception(this.m_translate.getMessage("NtVarNm", varName));
                }
                Variable variable2 = new Variable(this, name, newVal, valueProvider);
                variable2.IsConstant = isConst;
                this.m_Variables.Add(name, variable2);
                this.m_Dirty = true;
            }
        }

        private void UpperCase(char[] c)
        {
            int length = c.Length;
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                char ch = c[i];
                if (ch == '"')
                {
                    flag = !flag;
                }
                else if (!flag)
                {
                    c[i] = char.ToUpper(ch);
                }
            }
        }

        // Properties
        public CultureInfo CultureInfo
        {
            get
            {
                return this.m_CultureInfo;
            }
            set
            {
                this.m_CultureInfo = value;
            }
        }

        public string Expression
        {
            get
            {
                return this.m_Expression;
            }
            set
            {
                if (value != this.m_Expression)
                {
                    this.m_Expression = value;
                    this.m_Dirty = true;
                }
            }
        }

        public bool OptimizationOn
        {
            get
            {
                return this.m_OptimizationOn;
            }
            set
            {
                this.m_OptimizationOn = value;
            }
        }

        public STR_CONCAT_OP StrConcatOperator
        {
            get
            {
                return this.m_StrConcatOperator;
            }
            set
            {
                this.m_StrConcatOperator = value;
                if (value == STR_CONCAT_OP.AMPERSAND)
                {
                    this.m_AddOp = StandardLib.add_;
                    this.m_AndOp = StandardLib.andWithStr_;
                }
                else
                {
                    this.m_AddOp = StandardLib.addWithStr_;
                    this.m_AndOp = StandardLib.and_;
                }
            }
        }

        public bool StringLiteralsAllowed
        {
            get
            {
                return this.m_StringLiteralsAllowed;
            }
            set
            {
                this.m_StringLiteralsAllowed = value;
            }
        }

        public IConvertible Value
        {
            get
            {
                return this.Evaluate();
            }
        }

        public IConvertible ValueAsDouble
        {
            get
            {
                IConvertible convertible = this.Evaluate();
                if (convertible is string)
                {
                    return double.Parse((string)convertible, CultureInfo.InvariantCulture.NumberFormat);
                }
                return Convert.ToDouble(convertible);
            }
        }

        public IConvertible ValueAsString
        {
            get
            {
                return Convert.ToString(this.Evaluate());
            }
        }

        public IConvertible X
        {
            get
            {
                return this.GetVariable("X");
            }
            set
            {
                this.SetVariable("X", value, false, null);
            }
        }

        public IConvertible Y
        {
            get
            {
                return this.GetVariable("Y");
            }
            set
            {
                this.SetVariable("Y", value, false, null);
            }
        }

        // Nested Types
        public abstract class QuickSort
        {
            // Methods
            protected QuickSort()
            {
            }

            public abstract int compareTo(int i, int j);
            public void sort(int L, int R)
            {
                int num;
                do
                {
                    num = L;
                    int i = R;
                    int j = (L + R) >> 1;
                    do
                    {
                        while (this.compareTo(num, j) < 0)
                        {
                            num++;
                        }
                        while (this.compareTo(i, j) > 0)
                        {
                            i--;
                        }
                        if (num <= i)
                        {
                            this.swap(num, i);
                            if (j == num)
                            {
                                j = i;
                            }
                            else if (j == i)
                            {
                                j = num;
                            }
                            num++;
                            i--;
                        }
                    }
                    while (num <= i);
                    if (L < i)
                    {
                        this.sort(L, i);
                    }
                    L = num;
                }
                while (num < R);
            }

            public abstract void swap(int i, int j);
        }

        private class Sort : TruongViet.UnimOs.wsBusiness.MathParser.QuickSort
        {
            // Fields
            private object[] a;
            private CompareInfo collator;

            // Methods
            public Sort(CultureInfo aCultureInfo)
            {
                this.collator = CompareInfo.GetCompareInfo(aCultureInfo.LCID);
            }

            public override int compareTo(int i, int j)
            {
                return this.collator.Compare(this.a[i].ToString(), this.a[j].ToString());
            }

            public object[] sort(object[] objs)
            {
                if (objs.Length > 1)
                {
                    this.a = objs;
                    base.sort(0, objs.Length - 1);
                }
                return objs;
            }

            public override void swap(int i, int j)
            {
                object obj2 = this.a[i];
                this.a[i] = this.a[j];
                this.a[j] = obj2;
            }
        }
    }


    public abstract class Node : IParameter
    {
        // Methods
        protected Node()
        {
        }

        public abstract IConvertible GetValue();
        public abstract double GetValueAsDouble();
        public abstract string GetValueAsString();
        public abstract bool IsUsed(object Addr);
        public abstract void Optimize();
    }

    internal class NParamNode : Node
    {
        // Fields
        public IFunction fPtr;
        public Node[] nodes;

        // Methods
        public NParamNode(Node[] n, IFunction FuncAddr)
        {
            this.nodes = n;
            this.fPtr = FuncAddr;
        }

        public override IConvertible GetValue()
        {
            return this.fPtr.Run(this.nodes);
        }

        public override double GetValueAsDouble()
        {
            IConvertible convertible = this.fPtr.Run(this.nodes);
            if (convertible is double)
            {
                return (double)convertible;
            }
            if (convertible is string)
            {
                return double.Parse((string)convertible, CultureInfo.InvariantCulture.NumberFormat);
            }
            return Convert.ToDouble(convertible);
        }

        public override string GetValueAsString()
        {
            object obj2 = this.fPtr.Run(this.nodes);
            if (obj2 is string)
            {
                return (string)obj2;
            }
            return Convert.ToString(obj2);
        }

        public override bool IsUsed(object Addr)
        {
            for (int i = 0; i < this.nodes.Length; i++)
            {
                if (this.nodes[i].IsUsed(Addr))
                {
                    return true;
                }
            }
            return Addr.Equals(this.fPtr);
        }

        public override void Optimize()
        {
            for (int i = 0; i < this.nodes.Length; i++)
            {
                this.nodes[i] = TruongViet.UnimOs.wsBusiness.MathParser.OptimizeNode(this.nodes[i]);
            }
        }
    }

    public abstract class OneParameterFunc : IFunction
    {
        // Methods
        protected OneParameterFunc()
        {
        }

        public int GetNumberOfParams()
        {
            return 1;
        }

        public abstract IConvertible Run(IParameter[] p);
    }

    public delegate double OneParamFunc(IParameter x);

    internal class OneParamFuncAdapter : IFunction
    {
        // Fields
        private OneParamFunc m_EventHandler;

        // Methods
        public OneParamFuncAdapter(OneParamFunc eventHandler)
        {
            this.m_EventHandler = eventHandler;
        }

        public int GetNumberOfParams()
        {
            return 1;
        }

        public IConvertible Run(IParameter[] p)
        {
            return this.m_EventHandler(p[0]);
        }
    }

    public class ParserException : Exception
    {
        // Fields
        private string m_err;
        private string m_exp;

        // Methods
        public ParserException(string msg, string errPart, string expression)
            : base(msg)
        {
            this.m_err = errPart;
            this.m_exp = expression;
        }

        public string GetInvalidPortionOfExpression()
        {
            return this.m_err;
        }

        public string GetSubExpression()
        {
            return this.m_exp;
        }
    }

    public abstract class StandardLib
    {
        // Fields
        protected static OneParameterFunc abs_ = new __abs();
        protected static TwoParameterFunc add_ = new __add();
        protected static TwoParameterFunc addWithStr_ = new __addWithStr();
        protected static TwoParameterFunc and_ = new __and();
        protected static TwoParameterFunc andWithStr_ = new __andWithStr();
        protected static OneParameterFunc arctan_ = new __arctan();
        protected static OneParameterFunc ceil_ = new __ceil();
        protected static TwoParameterFunc chr_ = new __chr();
        protected static TwoParameterFunc concat_ = new __concat();
        protected static OneParameterFunc cos_ = new __cos();
        protected static OneParameterFunc cosh_ = new __cosh();
        protected static OneParameterFunc cotan_ = new __cotan();
        protected static TwoParameterFunc divide_ = new __divide();
        protected static TwoParameterFunc equals_ = new __equals();
        protected static OneParameterFunc exp_ = new __exp();
        protected static OneParameterFunc double_ = new __double();
        protected static OneParameterFunc floor_ = new __floor();
        protected static TwoParameterFunc greater_ = new __greater();
        protected static TwoParameterFunc gtequals_ = new __greaterOrEquals();
        protected static IFunction if_ = new __if();
        protected static TwoParameterFunc intdiv_ = new __intdiv();
        protected static TwoParameterFunc intpower_ = new __intpower();
        protected static TwoParameterFunc less_ = new __less();
        protected static OneParameterFunc ln_ = new __ln();
        protected static OneParameterFunc log10_ = new __log10();
        protected static OneParameterFunc log2_ = new __log2();
        protected static TwoParameterFunc logN_ = new __logN();
        protected static TwoParameterFunc lsequals_ = new __lessOrEquals();
        protected static OneParameterFunc ltrim_ = new __ltrim();
        protected static TwoParameterFunc max_ = new __max();
        protected static TwoParameterFunc min_ = new __min();
        protected static TwoParameterFunc modulo_ = new __modulo();
        protected static TwoParameterFunc multiply_ = new __multiply();
        protected static OneParameterFunc negate_ = new __negate();
        protected static OneParameterFunc not_ = new __not();
        protected static TwoParameterFunc notequals_ = new __notequals();
        protected static TwoParameterFunc or_ = new __or();
        protected static TwoParameterFunc power_ = new __power();
        protected static ZeroParameterFunc rnd_ = new __rnd();
        protected static OneParameterFunc rtrim_ = new __rtrim();
        protected static OneParameterFunc sign_ = new __sign();
        protected static OneParameterFunc sin_ = new __sin();
        protected static OneParameterFunc sinh_ = new __sinh();
        protected static OneParameterFunc sqrt_ = new __sqrt();
        protected static OneParameterFunc square_ = new __square();
        protected static OneParameterFunc str_ = new __str();
        protected static OneParameterFunc strlen_ = new __strlen();
        protected static IFunction substr_ = new __substr();
        protected static TwoParameterFunc subtract_ = new __subtract();
        protected static IFunction sum_ = new __sum();
        protected static OneParameterFunc tan_ = new __tan();
        protected static OneParameterFunc trim_ = new __trim();
        protected static OneParameterFunc trunc_ = new __trunc();
        protected static OneParameterFunc unaryadd_ = new __unaryadd();

        // Methods
        protected StandardLib()
        {
        }

        // Nested Types
        private class __abs : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Abs(p[0].GetValueAsDouble());
            }
        }

        private class __add : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                return (valueAsDouble + num2);
            }
        }

        private class __addWithStr : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return (((string)convertible) + p[1].GetValueAsString());
                }
                IConvertible convertible2 = p[1].GetValue();
                if (convertible2 is string)
                {
                    return (Convert.ToString(convertible) + ((string)convertible2));
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double num2 = (convertible2 is double) ? ((double)convertible2) : Convert.ToDouble(convertible2);
                return (num + num2);
            }
        }

        private class __and : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                return (((valueAsDouble > 0.0) && (num2 > 0.0)) ? 1 : 0);
            }
        }

        private class __andWithStr : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return (((string)convertible) + p[1].GetValueAsString());
                }
                IConvertible convertible2 = p[1].GetValue();
                if (convertible2 is string)
                {
                    return (Convert.ToString(convertible) + ((string)convertible2));
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double num2 = (convertible2 is double) ? ((double)convertible2) : Convert.ToDouble(convertible2);
                return (((num > 0.0) && (num2 > 0.0)) ? 1 : 0);
            }
        }

        private class __arctan : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Atan(p[0].GetValueAsDouble());
            }
        }

        private class __ceil : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Ceiling(p[0].GetValueAsDouble());
            }
        }

        private class __chr : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                char ch;
                IConvertible convertible = p[0].GetValue();
                int num = Convert.ToInt32(p[1].GetValue());
                if (convertible is string)
                {
                    ch = ((string)convertible)[num];
                    return ch.ToString();
                }
                ch = Convert.ToString(convertible)[num];
                return ch.ToString();
            }
        }

        private class __concat : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < p.Length; i++)
                {
                    builder.Append(p[i].GetValueAsString());
                }
                return builder.ToString();
            }
        }

        private class __cos : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Cos(p[0].GetValueAsDouble());
            }
        }

        private class __cosh : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                return ((Math.Exp(valueAsDouble) + Math.Exp(-valueAsDouble)) * 0.5);
            }
        }

        private class __cotan : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return (1.0 / Math.Tan(p[0].GetValueAsDouble()));
            }
        }

        private class __divide : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                return (valueAsDouble / num2);
            }
        }

        private class __equals : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    string str = (string)convertible;
                    string valueAsString = p[1].GetValueAsString();
                    return (str.Equals(valueAsString) ? 1 : 0);
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double valueAsDouble = p[1].GetValueAsDouble();
                return ((num == valueAsDouble) ? 1 : 0);
            }
        }

        private class __exp : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Exp(p[0].GetValueAsDouble());
            }
        }

        private class __double : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return Convert.ToDouble((string)convertible);
                }
                return Convert.ToDouble(convertible);
            }
        }

        private class __floor : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Floor(p[0].GetValueAsDouble());
            }
        }

        private class __greater : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    string str = (string)convertible;
                    string valueAsString = p[1].GetValueAsString();
                    return ((str.CompareTo(valueAsString) > 0) ? 1 : 0);
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double valueAsDouble = p[1].GetValueAsDouble();
                return ((num > valueAsDouble) ? 1 : 0);
            }
        }

        private class __greaterOrEquals : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    string str = (string)convertible;
                    string valueAsString = p[1].GetValueAsString();
                    return ((str.CompareTo(valueAsString) >= 0) ? 1 : 0);
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double valueAsDouble = p[1].GetValueAsDouble();
                return ((num >= valueAsDouble) ? 1 : 0);
            }
        }

        private class __if : IFunction
        {
            // Methods
            public int GetNumberOfParams()
            {
                return 3;
            }

            public IConvertible Run(IParameter[] p)
            {
                if (p[0].GetValueAsDouble() == 0.0)
                {
                    return p[2].GetValue();
                }
                return p[1].GetValue();
            }
        }

        private class __intdiv : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double d = p[1].GetValueAsDouble();
                return Math.Floor((double)(Math.Floor(valueAsDouble) / Math.Floor(d)));
            }
        }

        private class __intpower : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double d = p[1].GetValueAsDouble();
                return Math.Pow(valueAsDouble, Math.Floor(d));
            }
        }

        private class __less : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    string strB = (string)convertible;
                    return ((p[1].GetValueAsString().CompareTo(strB) > 0) ? 1 : 0);
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double valueAsDouble = p[1].GetValueAsDouble();
                return ((num < valueAsDouble) ? 1 : 0);
            }
        }

        private class __lessOrEquals : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    string strB = (string)convertible;
                    return ((p[1].GetValueAsString().CompareTo(strB) >= 0) ? 1 : 0);
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double valueAsDouble = p[1].GetValueAsDouble();
                return ((num <= valueAsDouble) ? 1 : 0);
            }
        }

        private class __ln : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Log(p[0].GetValueAsDouble());
            }
        }

        private class __log10 : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return (Math.Log(p[0].GetValueAsDouble()) / Math.Log(10.0));
            }
        }

        private class __log2 : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return (Math.Log(p[0].GetValueAsDouble()) / Math.Log(2.0));
            }
        }

        private class __logN : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return (Math.Log(p[0].GetValueAsDouble()) / Math.Log(p[1].GetValueAsDouble()));
            }
        }

        private class __ltrim : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return ((string)convertible).TrimStart(new char[0]);
                }
                return Convert.ToString(convertible).TrimStart(new char[0]);
            }
        }

        private class __max : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                if (valueAsDouble > num2)
                {
                    return valueAsDouble;
                }
                return num2;
            }
        }

        private class __min : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                if (valueAsDouble < num2)
                {
                    return valueAsDouble;
                }
                return num2;
            }
        }

        private class __modulo : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double d = p[1].GetValueAsDouble();
                int num3 = (int)Math.Floor(valueAsDouble);
                int num4 = (int)Math.Floor(d);
                return (num3 % num4);
            }
        }

        private class __multiply : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                return (valueAsDouble * num2);
            }
        }

        private class __negate : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return -p[0].GetValueAsDouble();
            }
        }

        private class __not : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return ((p[0].GetValueAsDouble() == 0.0) ? 1 : 0);
            }
        }

        private class __notequals : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    string str = (string)convertible;
                    string valueAsString = p[1].GetValueAsString();
                    return (!str.Equals(valueAsString) ? 1 : 0);
                }
                double num = (convertible is double) ? ((double)convertible) : Convert.ToDouble(convertible);
                double valueAsDouble = p[1].GetValueAsDouble();
                return ((num != valueAsDouble) ? 1 : 0);
            }
        }

        private class __or : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                return (((valueAsDouble > 0.0) || (num2 > 0.0)) ? 1 : 0);
            }
        }

        private class __power : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double y = p[1].GetValueAsDouble();
                return Math.Pow(valueAsDouble, y);
            }
        }

        private class __rnd : ZeroParameterFunc
        {
            // Fields
            private Random random;

            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                lock (this)
                {
                    if (this.random == null)
                    {
                        this.random = new Random();
                    }
                    return this.random.NextDouble();
                }
            }
        }

        private class __rtrim : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return ((string)convertible).TrimEnd(new char[0]);
                }
                return Convert.ToString(convertible).TrimEnd(new char[0]);
            }
        }

        private class __sign : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                if (valueAsDouble < 0.0)
                {
                    return -1;
                }
                if (valueAsDouble > 0.0)
                {
                    return 1.0;
                }
                return 0.0;
            }
        }

        private class __sin : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Sin(p[0].GetValueAsDouble());
            }
        }

        private class __sinh : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                return ((Math.Exp(valueAsDouble) - Math.Exp(-valueAsDouble)) * 0.5);
            }
        }

        private class __sqrt : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Sqrt(p[0].GetValueAsDouble());
            }
        }

        private class __square : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                return (valueAsDouble * valueAsDouble);
            }
        }

        private class __str : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return convertible;
                }
                return Convert.ToString(convertible);
            }
        }

        private class __strlen : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Convert.ToDouble(p[0].GetValueAsString().Length);
            }
        }

        private class __substr : IFunction
        {
            // Methods
            public int GetNumberOfParams()
            {
                return 3;
            }

            public IConvertible Run(IParameter[] p)
            {
                string valueAsString = p[0].GetValueAsString();
                int valueAsDouble = (int)p[1].GetValueAsDouble();
                int num2 = (int)p[2].GetValueAsDouble();
                num2 = Math.Min(num2, valueAsString.Length - valueAsDouble);
                return valueAsString.Substring(valueAsDouble, num2);
            }
        }

        private class __subtract : TwoParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                double num2 = p[1].GetValueAsDouble();
                return (valueAsDouble - num2);
            }
        }

        private class __sum : IFunction
        {
            // Methods
            public int GetNumberOfParams()
            {
                return -1;
            }

            public IConvertible Run(IParameter[] p)
            {
                double num = 0.0;
                for (int i = 0; i < p.Length; i++)
                {
                    num += p[i].GetValueAsDouble();
                }
                return num;
            }
        }

        private class __tan : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return Math.Tan(p[0].GetValueAsDouble());
            }
        }

        private class __trim : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                IConvertible convertible = p[0].GetValue();
                if (convertible is string)
                {
                    return ((string)convertible).Trim();
                }
                return Convert.ToString(convertible).Trim();
            }
        }

        private class __trunc : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                double valueAsDouble = p[0].GetValueAsDouble();
                if (valueAsDouble >= 0.0)
                {
                    return Math.Floor(valueAsDouble);
                }
                return Math.Ceiling(valueAsDouble);
            }
        }

        private class __unaryadd : OneParameterFunc
        {
            // Methods
            public override IConvertible Run(IParameter[] p)
            {
                return p[0].GetValueAsDouble();
            }
        }
    }

    public enum STR_CONCAT_OP
    {
        PLUS,
        AMPERSAND
    }

    public sealed class StrUtil
    {
        // Methods
        public static string Replace(string src, char from)
        {
            int num;
            if ((src == null) || ((num = src.IndexOf(from)) == -1))
            {
                return src;
            }
            char[] chArray = src.ToCharArray();
            StringBuilder builder = new StringBuilder(chArray.Length);
            int startIndex = 0;
            do
            {
                builder.Append(chArray, startIndex, num - startIndex);
                startIndex = num + 1;
            }
            while ((num = src.IndexOf(from, startIndex)) != -1);
            builder.Append(chArray, startIndex, chArray.Length - startIndex);
            return builder.ToString();
        }

        public static string Replace(string src, char from, string to)
        {
            int num;
            if ((src == null) || ((num = src.IndexOf(from)) == -1))
            {
                return src;
            }
            char[] chArray = src.ToCharArray();
            StringBuilder builder = new StringBuilder(chArray.Length);
            int startIndex = 0;
            do
            {
                builder.Append(chArray, startIndex, num - startIndex);
                builder.Append(to);
                startIndex = num + 1;
            }
            while ((num = src.IndexOf(from, startIndex)) != -1);
            builder.Append(chArray, startIndex, chArray.Length - startIndex);
            return builder.ToString();
        }

        public static string Replace(string src, string from, char to)
        {
            int num;
            if ((src == null) || ((num = src.IndexOf(from)) == -1))
            {
                return src;
            }
            char[] chArray = src.ToCharArray();
            StringBuilder builder = new StringBuilder(chArray.Length);
            int startIndex = 0;
            int length = from.Length;
            do
            {
                builder.Append(chArray, startIndex, num - startIndex);
                builder.Append(to);
                startIndex = num + length;
            }
            while ((num = src.IndexOf(from, startIndex)) != -1);
            builder.Append(chArray, startIndex, chArray.Length - startIndex);
            return builder.ToString();
        }

        public static string Replace(string src, string from, string to)
        {
            int num;
            if ((src == null) || ((num = src.IndexOf(from)) == -1))
            {
                return src;
            }
            char[] chArray = src.ToCharArray();
            StringBuilder builder = new StringBuilder(chArray.Length);
            int startIndex = 0;
            int length = from.Length;
            do
            {
                builder.Append(chArray, startIndex, num - startIndex);
                builder.Append(to);
                startIndex = num + length;
            }
            while ((num = src.IndexOf(from, startIndex)) != -1);
            builder.Append(chArray, startIndex, chArray.Length - startIndex);
            return builder.ToString();
        }
    }

    internal class Translator
    {
        // Fields
        public Hashtable res;

        // Methods
        public Translator(Hashtable strings)
        {
            this.res = strings;
        }

        public string getMessage(string key)
        {
            try
            {
                string str = (string)this.res[key];
                if (str == null)
                {
                    str = key;
                }
                return str;
            }
            catch (Exception)
            {
                return key;
            }
        }

        public string getMessage(string key, string param)
        {
            return string.Format(this.getMessage(key), new object[] { param });
        }

        public string getMessage(string key, string param0, string param1)
        {
            return string.Format(this.getMessage(key), new object[] { param0, param1 });
        }
    }

    public abstract class TwoParameterFunc : IFunction
    {
        // Methods
        protected TwoParameterFunc()
        {
        }

        public int GetNumberOfParams()
        {
            return 2;
        }

        public abstract IConvertible Run(IParameter[] p);
    }


    public delegate double TwoParamFunc(IParameter x, IParameter y);

    internal class TwoParamFuncAdapter : IFunction
    {
        // Fields
        private TwoParamFunc m_EventHandler;

        // Methods
        public TwoParamFuncAdapter(TwoParamFunc eventHandler)
        {
            this.m_EventHandler = eventHandler;
        }

        public int GetNumberOfParams()
        {
            return 2;
        }

        public IConvertible Run(IParameter[] p)
        {
            return this.m_EventHandler(p[0], p[1]);
        }
    }

    internal class Variable
    {
        // Fields
        private bool m_IsConstant;
        private string m_Name;
        private TruongViet.UnimOs.wsBusiness.MathParser m_Parser;
        private IConvertible m_Value;
        private VariableDelegate m_ValueProvider;

        // Methods
        private Variable()
        {
        }

        public Variable(TruongViet.UnimOs.wsBusiness.MathParser parser, string aName, IConvertible newVal, VariableDelegate valueProvider)
        {
            this.m_Parser = parser;
            this.m_Name = aName;
            this.m_Value = newVal;
            this.m_ValueProvider = valueProvider;
        }

        public IConvertible GetRuntimeValue()
        {
            if (this.m_ValueProvider != null)
            {
                return this.m_ValueProvider(this.m_Parser, this.m_Name);
            }
            return this.m_Value;
        }

        // Properties
        public bool IsConstant
        {
            get
            {
                return this.m_IsConstant;
            }
            set
            {
                this.m_IsConstant = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }
            set
            {
                this.m_Name = value;
            }
        }

        public IConvertible Value
        {
            get
            {
                return this.m_Value;
            }
            set
            {
                this.m_Value = value;
            }
        }

        public VariableDelegate ValueProvider
        {
            get
            {
                return this.m_ValueProvider;
            }
            set
            {
                this.m_ValueProvider = value;
            }
        }
    }

    public delegate IConvertible VariableDelegate(TruongViet.UnimOs.wsBusiness.MathParser parser, string varName);

    internal class VarNode : Node
    {
        // Fields
        private Variable pVar;

        // Methods
        public VarNode(Variable variable)
        {
            this.pVar = variable;
        }

        public override IConvertible GetValue()
        {
            return this.pVar.GetRuntimeValue();
        }

        public override double GetValueAsDouble()
        {
            IConvertible runtimeValue = this.pVar.GetRuntimeValue();
            if (runtimeValue is double)
            {
                return (double)runtimeValue;
            }
            if (runtimeValue is string)
            {
                return double.Parse((string)runtimeValue, CultureInfo.InvariantCulture.NumberFormat);
            }
            return Convert.ToDouble(runtimeValue);
        }

        public override string GetValueAsString()
        {
            IConvertible runtimeValue = this.pVar.GetRuntimeValue();
            if (runtimeValue is string)
            {
                return (string)runtimeValue;
            }
            return Convert.ToString(runtimeValue);
        }

        public override bool IsUsed(object Addr)
        {
            return Addr.Equals(this.pVar);
        }

        public override void Optimize()
        {
        }
    }

    public abstract class ZeroParameterFunc : IFunction
    {
        // Methods
        protected ZeroParameterFunc()
        {
        }

        public int GetNumberOfParams()
        {
            return 0;
        }

        public abstract IConvertible Run(IParameter[] p);
    }
}