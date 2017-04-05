﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.Grammars;

namespace Parser.Tokens
{
    public class TokenBase
    {
        public char Ch { get; private set; }
        public long Line { get; private set; }
        public long Coll { get; set; }
        public virtual bool IsTerminal => true;
        public Lexical lexical;
        public virtual Lexical Lexical => lexical ?? (lexical = Grammar.FindRight(Ch));

        public TokenBase(char ch, long line, long coll)
        {
            Ch = ch;
            Line = line;
            Coll = coll;
        }

        public override string ToString()
        {
            return Ch + " => " + Lexical;
        }
    }

    public class Token : TokenBase
    {
        public string Srt { get; set; }
        public string Name => Srt;
        public long End { get; set; }
        //public override Lexical Lexical =>  Grammar.FindRight(Srt);
        public Token() : base('\0', 0, 0)
        {
            
        }
        public Token(string str, long line, long coll) : base(str[0], line, coll)
        {
            Srt = str;
            End = Srt.Length;
        }
        
        public override bool IsTerminal => Grammar.Get(Srt) == null ? false : true;

        public void UpdateLexical ()
        {
            this.lexical = Grammar.FindRight(Srt);
        }

        public override string ToString()
        {
            return Srt + " => " + Lexical;
        }
    }

    public class Token2
    {
        public class TokenLoc
        {
            public class TokenPosition
            {
                public int Line { get; set; }
                public int Column { get; set; }
            }

            public TokenPosition start { get; set; }
            public TokenPosition end { get; set; }
        }

        public class TokenRange
        {
            public int start { get; set; }
            public int end { get; set; }
        }


        public int start { get; set; }
        public int end { get; set; }
        //public TokenType type { get; set; }
        public string value { get; set; }
        internal int lineNumber { get; set; }
        internal int lineStart { get; set; }
        public TokenRange range { get; set; }
        //public Loc loc { get; set; }
        internal bool octal { get; set; }
        internal string literal { get; set; }
        //public Regex regex;
        public int prec { get; set; }

        //public override string ToString()
        //{
        //    return String.Format("{0}[{1}:{2};{3}] {4}", type, lineNumber, start, end, value);
        //}

        public bool head { get; set; }

        //public List<Comment> trailingComments { get; set; }

        //public bool tail { get; set; }

        public Token2()
        {
            range = new TokenRange();
        }

    }
}