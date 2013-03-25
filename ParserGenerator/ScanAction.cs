//
//  This CSharp output file generated by Gardens Point LEX
//  Version:  1.2.0
//  Machine:  LKCZXVZ
//  DateTime: 3/25/2013 4:11:31 PM
//  UserName: ellingsd
//  GPLEX input file <ScanAction.lex - 1/3/2013 3:11:02 PM>
//  GPLEX frame file <embedded resource>
//
//  Option settings: verbose, noParser, noFiles, minimize
//  Option settings: compressNext, noEmbedBuffers
//

//
// Experimental embedded frame
// Version 1.1.4 of 10-May-2010
//
//
#define BACKUP
#define STANDALONE
#define NOFILES
#define PERSIST
#define BYTEMODE

using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Diagnostics.CodeAnalysis;

using QUT.GplexBuffers;
using QUT.GPGen.Parser;

namespace QUT.GPGen.Lexers
{   
    /// <summary>
    /// Summary Canonical example of GPLEX automaton
    /// </summary>
    
#if STANDALONE
    //
    // These are the dummy declarations for stand-alone GPLEX applications
    // normally these declarations would come from the parser.
    // If you declare /noparser, or %option noparser then you get this.
    //

     internal enum ActionToken
    { 
      EOF = 0, maxParseToken = int.MaxValue 
      // must have at least these two, values are almost arbitrary
    }

     internal abstract class ActionBase
    {
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "yylex")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "yylex")]
        public abstract int yylex();

        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "yywrap")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "yywrap")]
        protected virtual bool yywrap() { return true; }

#if BABEL
        protected abstract int CurrentSc { get; set; }
        // EolState is the 32-bit of state data persisted at 
        // the end of each line for Visual Studio colorization.  
        // The default is to return CurrentSc.  You must override
        // this if you want more complicated behavior.
        public virtual int EolState { 
            get { return CurrentSc; }
            set { CurrentSc = value; } 
        }
    }
    
     internal interface IColorScan
    {
        void SetSource(string source, int offset);
        int GetNext(ref int state, out int start, out int end);
#endif // BABEL
    }

#endif // STANDALONE
    
    // If the compiler can't find the scanner base class maybe you
    // need to run GPPG with the /gplex option, or GPLEX with /noparser
#if BABEL
     internal sealed partial class ActionScanner : ActionBase, IColorScan
    {
        private ScanBuff buffer;
        int currentScOrd;  // start condition ordinal
        
        protected override int CurrentSc 
        {
             // The current start state is a property
             // to try to avoid the user error of setting
             // scState but forgetting to update the FSA
             // start state "currentStart"
             //
             get { return currentScOrd; }  // i.e. return YY_START;
             set { currentScOrd = value;   // i.e. BEGIN(value);
                   currentStart = startState[value]; }
        }
#else  // BABEL
     internal sealed partial class ActionScanner : ActionBase
    {
        private ScanBuff buffer;
        int currentScOrd;  // start condition ordinal
#endif // BABEL
        
        /// <summary>
        /// The input buffer for this scanner.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public ScanBuff Buffer { get { return buffer; } }
        
        private static int GetMaxParseToken() {
     System.Reflection.FieldInfo f = typeof(ActionToken).GetField("maxParseToken");
            return (f == null ? int.MaxValue : (int)f.GetValue(null));
        }
        
        static int parserMax = GetMaxParseToken();
        
        enum Result {accept, noMatch, contextFound};

        const int maxAccept = 28;
        const int initial = 29;
        const int eofNum = 0;
        const int goStart = -1;
        const int INITIAL = 0;
        const int LitString = 1;
        const int VrbString = 2;
        const int LitChar = 3;

#region user code
/*
 *  Using GPLEX to check validity of action strings
 *  Author: John Gough, 2008
 */
int length;
   int colNo;
   int lineNo;
   LexSpan src;
   ErrorHandler handler;
#endregion user code

        int state;
        int currentStart = startState[0];
        int code;      // last code read
        int cCol;      // column number of code
        int lNum;      // current line number
        //
        // The following instance variables are used, among other
        // things, for constructing the yylloc location objects.
        //
        int tokPos;        // buffer position at start of token
        int tokCol;        // zero-based column number at start of token
        int tokLin;        // line number at start of token
        int tokEPos;       // buffer position at end of token
        int tokECol;       // column number at end of token
        int tokELin;       // line number at end of token
        string tokTxt;     // lazily constructed text of token
#if STACK          
        private Stack<int> scStack = new Stack<int>();
#endif // STACK

#region ScannerTables
    struct Table {
        public int min; public int rng; public int dflt;
        public sbyte[] nxt;
        public Table(int m, int x, int d, sbyte[] n) {
            min = m; rng = x; dflt = d; nxt = n;
        }
    };

    static int[] startState = new int[] {29, 34, 35, 36, 0};

    static Table[] NxS = new Table[37] {
/* NxS[   0] */ new Table(0, 0, 0, null), // Shortest string ""
/* NxS[   1] */ new Table(0, 0, -1, null), // Shortest string "\x01"
/* NxS[   2] */ new Table(0, 0, -1, null), // Shortest string "\n"
/* NxS[   3] */ // Shortest string "\r"
      new Table(10, 1, -1, new sbyte[] {2}),
/* NxS[   4] */ new Table(0, 0, -1, null), // Shortest string "\""
/* NxS[   5] */ new Table(0, 0, -1, null), // Shortest string "'"
/* NxS[   6] */ new Table(0, 0, -1, null), // Shortest string "$\x01"
/* NxS[   7] */ new Table(0, 0, -1, null), // Shortest string "@\""
/* NxS[   8] */ new Table(0, 0, -1, null), // Shortest string "$$"
/* NxS[   9] */ // Shortest string "$0"
      new Table(48, 10, -1, new sbyte[] {9, 9, 9, 9, 9, 9, 
          9, 9, 9, 9}),
/* NxS[  10] */ // Shortest string "$<"
      new Table(10, 53, 32, new sbyte[] {-1, 32, 32, -1, 32, 32, 
          32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
          32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
          32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, -1}),
/* NxS[  11] */ // Shortest string "$<\x01>0"
      new Table(48, 10, -1, new sbyte[] {11, 11, 11, 11, 11, 11, 
          11, 11, 11, 11}),
/* NxS[  12] */ new Table(0, 0, -1, null), // Shortest string "\x01"
/* NxS[  13] */ new Table(0, 0, -1, null), // Shortest string "\n"
/* NxS[  14] */ // Shortest string "\r"
      new Table(10, 1, -1, new sbyte[] {13}),
/* NxS[  15] */ new Table(0, 0, -1, null), // Shortest string "\""
/* NxS[  16] */ // Shortest string "\\"
      new Table(34, 59, -1, new sbyte[] {17, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, 17}),
/* NxS[  17] */ new Table(0, 0, -1, null), // Shortest string "\\\""
/* NxS[  18] */ new Table(0, 0, -1, null), // Shortest string "\x01"
/* NxS[  19] */ new Table(0, 0, -1, null), // Shortest string "\n"
/* NxS[  20] */ // Shortest string "\r"
      new Table(10, 1, -1, new sbyte[] {19}),
/* NxS[  21] */ // Shortest string "\""
      new Table(34, 1, -1, new sbyte[] {22}),
/* NxS[  22] */ new Table(0, 0, -1, null), // Shortest string "\"\""
/* NxS[  23] */ new Table(0, 0, -1, null), // Shortest string "\x01"
/* NxS[  24] */ new Table(0, 0, -1, null), // Shortest string "\n"
/* NxS[  25] */ // Shortest string "\r"
      new Table(10, 1, -1, new sbyte[] {24}),
/* NxS[  26] */ new Table(0, 0, -1, null), // Shortest string "'"
/* NxS[  27] */ // Shortest string "\\"
      new Table(39, 54, -1, new sbyte[] {28, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
          -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 28}),
/* NxS[  28] */ new Table(0, 0, -1, null), // Shortest string "\\'"
/* NxS[  29] */ // Shortest string ""
      new Table(10, 55, 1, new sbyte[] {2, 1, 1, 3, 1, 1, 
          1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 
          1, 1, 4, 1, 30, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 1, 
          1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 
          31}),
/* NxS[  30] */ // Shortest string "$"
      new Table(10, 55, 6, new sbyte[] {-1, 6, 6, -1, 6, 6, 
          6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 
          6, 6, 6, 6, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 
          9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 6, 6, 10, 6, 6, 6, 
          -1}),
/* NxS[  31] */ // Shortest string "@"
      new Table(10, 55, 6, new sbyte[] {-1, 6, 6, -1, 6, 6, 
          6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 
          6, 6, 7, 6, 8, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 
          9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 6, 6, 6, 6, 6, 6, 
          -1}),
/* NxS[  32] */ // Shortest string "$<\x01"
      new Table(10, 53, 32, new sbyte[] {-1, 32, 32, -1, 32, 32, 
          32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
          32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
          32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 33}),
/* NxS[  33] */ // Shortest string "$<\x01>"
      new Table(48, 10, -1, new sbyte[] {11, 11, 11, 11, 11, 11, 
          11, 11, 11, 11}),
/* NxS[  34] */ // Shortest string ""
      new Table(10, 83, 12, new sbyte[] {13, 12, 12, 14, 12, 12, 
          12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 
          12, 12, 15, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 
          12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 
          12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 
          12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 16}),
/* NxS[  35] */ // Shortest string ""
      new Table(10, 25, 18, new sbyte[] {19, 18, 18, 20, 18, 18, 
          18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 
          18, 18, 21}),
/* NxS[  36] */ // Shortest string ""
      new Table(10, 83, 23, new sbyte[] {24, 23, 23, 25, 23, 23, 
          23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 
          23, 23, 23, 23, 23, 23, 23, 26, 23, 23, 23, 23, 23, 23, 23, 23, 
          23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 
          23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 
          23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 27}),
    };

int NextState() {
    if (code == ScanBuff.EndOfFile)
        return eofNum;
    else
        unchecked {
            int rslt;
            int idx = (byte)(code - NxS[state].min);
            if ((uint)idx >= (uint)NxS[state].rng) rslt = NxS[state].dflt;
            else rslt = NxS[state].nxt[idx];
            return rslt;
        }
}

#endregion


#if BACKUP
        // ==============================================================
        // == Nested struct used for backup in automata that do backup ==
        // ==============================================================

        struct Context // class used for automaton backup.
        {
            public int bPos;
            public int rPos; // scanner.readPos saved value
            public int cCol;
            public int lNum; // Need this in case of backup over EOL.
            public int state;
            public int cChr;
        }
        
        private Context ctx = new Context();
#endif // BACKUP

        // ==============================================================
        // ==== Nested struct to support input switching in scanners ====
        // ==============================================================

		struct BufferContext {
            internal ScanBuff buffSv;
			internal int chrSv;
			internal int cColSv;
			internal int lNumSv;
		}

        // ==============================================================
        // ===== Private methods to save and restore buffer contexts ====
        // ==============================================================

        /// <summary>
        /// This method creates a buffer context record from
        /// the current buffer object, together with some
        /// scanner state values. 
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        BufferContext MkBuffCtx()
		{
			BufferContext rslt;
			rslt.buffSv = this.buffer;
			rslt.chrSv = this.code;
			rslt.cColSv = this.cCol;
			rslt.lNumSv = this.lNum;
			return rslt;
		}

        /// <summary>
        /// This method restores the buffer value and allied
        /// scanner state from the given context record value.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        void RestoreBuffCtx(BufferContext value)
		{
			this.buffer = value.buffSv;
			this.code = value.chrSv;
			this.cCol = value.cColSv;
			this.lNum = value.lNumSv;
        } 
        // =================== End Nested classes =======================

#if !NOFILES
     internal ActionScanner(Stream file) {
            SetSource(file); // no unicode option
        }   
#endif // !NOFILES

     internal ActionScanner() { }

        private int readPos;

        void GetCode()
        {
            if (code == '\n')  // This needs to be fixed for other conventions
                               // i.e. [\r\n\205\u2028\u2029]
            { 
                cCol = -1;
                lNum++;
            }
            readPos = buffer.Pos;

            // Now read new codepoint.
            code = buffer.Read();
            if (code > ScanBuff.EndOfFile)
            {
#if (!BYTEMODE)
                if (code >= 0xD800 && code <= 0xDBFF)
                {
                    int next = buffer.Read();
                    if (next < 0xDC00 || next > 0xDFFF)
                        code = ScanBuff.UnicodeReplacementChar;
                    else
                        code = (0x10000 + ((code & 0x3FF) << 10) + (next & 0x3FF));
                }
#endif
                cCol++;
            }
        }

        void MarkToken()
        {
#if (!PERSIST)
            buffer.Mark();
#endif
            tokPos = readPos;
            tokLin = lNum;
            tokCol = cCol;
        }
        
        void MarkEnd()
        {
            tokTxt = null;
            tokEPos = readPos;
            tokELin = lNum;
            tokECol = cCol;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        int Peek()
        {
            int rslt, codeSv = code, cColSv = cCol, lNumSv = lNum, bPosSv = buffer.Pos;
            GetCode(); rslt = code;
            lNum = lNumSv; cCol = cColSv; code = codeSv; buffer.Pos = bPosSv;
            return rslt;
        }

        // ==============================================================
        // =====    Initialization of string-based input buffers     ====
        // ==============================================================

        /// <summary>
        /// Create and initialize a StringBuff buffer object for this scanner
        /// </summary>
        /// <param name="source">the input string</param>
        /// <param name="offset">starting offset in the string</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void SetSource(string source, int offset)
        {
            this.buffer = ScanBuff.GetBuffer(source);
            this.buffer.Pos = offset;
            this.lNum = 0;
            this.code = '\n'; // to initialize yyline, yycol and lineStart
            GetCode();
        }

        // ================ LineBuffer Initialization ===================
        /// <summary>
        /// Create and initialize a LineBuff buffer object for this scanner
        /// </summary>
        /// <param name="source">the list of input strings</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void SetSource(IList<string> source)
        {
            this.buffer = ScanBuff.GetBuffer(source);
            this.code = '\n'; // to initialize yyline, yycol and lineStart
            this.lNum = 0;
            GetCode();
        }

#if !NOFILES        
        // =============== StreamBuffer Initialization ==================

        /// <summary>
        /// Create and initialize a StreamBuff buffer object for this scanner.
        /// StreamBuff is buffer for 8-bit byte files.
        /// </summary>
        /// <param name="source">the input byte stream</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void SetSource(Stream source)
        {
            this.buffer = ScanBuff.GetBuffer(source);
            this.lNum = 0;
            this.code = '\n'; // to initialize yyline, yycol and lineStart
            GetCode();
        }
        
#if !BYTEMODE
        // ================ TextBuffer Initialization ===================

        /// <summary>
        /// Create and initialize a TextBuff buffer object for this scanner.
        /// TextBuff is a buffer for encoded unicode files.
        /// </summary>
        /// <param name="source">the input text file</param>
        /// <param name="fallbackCodePage">Code page to use if file has
        /// no BOM. For 0, use machine default; for -1, 8-bit binary</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public void SetSource(Stream source, int fallbackCodePage)
        {
            this.buffer = ScanBuff.GetBuffer(source, fallbackCodePage);
            this.lNum = 0;
            this.code = '\n'; // to initialize yyline, yycol and lineStart
            GetCode();
        }
#endif // !BYTEMODE
#endif // !NOFILES
        
        // ==============================================================

#if BABEL
        //
        //  Get the next token for Visual Studio
        //
        //  "state" is the inout mode variable that maintains scanner
        //  state between calls, using the EolState property. In principle,
        //  if the calls of EolState are costly set could be called once
        //  only per line, at the start; and get called only at the end
        //  of the line. This needs more infrastructure ...
        //
        public int GetNext(ref int state, out int start, out int end)
        {
                ActionToken next;
            int s, e;
            s = state;        // state at start
            EolState = state;
                next = (ActionToken)Scan();
            state = EolState;
            e = state;       // state at end;
            start = tokPos;
            end = tokEPos - 1; // end is the index of last char.
            return (int)next;
        }        
#endif // BABEL

        // ======== AbstractScanner<> Implementation =========

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "yylex")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "yylex")]
        public override int yylex()
        {
            // parserMax is set by reflecting on the Tokens
            // enumeration.  If maxParseToken is defined
            // that is used, otherwise int.MaxValue is used.
            int next;
            do { next = Scan(); } while (next >= parserMax);
            return next;
        }
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        int yypos { get { return tokPos; } }
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        int yyline { get { return tokLin; } }
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        int yycol { get { return tokCol; } }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "yytext")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "yytext")]
        public string yytext
        {
            get 
            {
                if (tokTxt == null) 
                    tokTxt = buffer.GetString(tokPos, tokEPos);
                return tokTxt;
            }
        }

        /// <summary>
        /// Discards all but the first "n" codepoints in the recognized pattern.
        /// Resets the buffer position so that only n codepoints have been consumed;
        /// yytext is also re-evaluated. 
        /// </summary>
        /// <param name="n">The number of codepoints to consume</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        void yyless(int n)
        {
            buffer.Pos = tokPos;
            // Must read at least one char, so set before start.
            cCol = tokCol - 1; 
            GetCode();
            // Now ensure that line counting is correct.
            lNum = tokLin;
            // And count the rest of the text.
            for (int i = 0; i < n; i++) GetCode();
            MarkEnd();
        }
       
        //
        //  It would be nice to count backward in the text
        //  but it does not seem possible to re-establish
        //  the correct column counts except by going forward.
        //
        /// <summary>
        /// Removes the last "n" code points from the pattern.
        /// </summary>
        /// <param name="n">The number to remove</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        void _yytrunc(int n) { yyless(yyleng - n); }
        
        //
        // This is painful, but we no longer count
        // codepoints.  For the overwhelming majority 
        // of cases the single line code is fast, for
        // the others, well, at least it is all in the
        // buffer so no files are touched. Note that we
        // can't use (tokEPos - tokPos) because of the
        // possibility of surrogate pairs in the token.
        //
        /// <summary>
        /// The length of the pattern in codepoints (not the same as 
        /// string-length if the pattern contains any surrogate pairs).
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "yyleng")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "yyleng")]
        public int yyleng
        {
            get {
                if (tokELin == tokLin)
                    return tokECol - tokCol;
                else
#if BYTEMODE
                    return tokEPos - tokPos;
#else
                {
                    int ch;
                    int count = 0;
                    int save = buffer.Pos;
                    buffer.Pos = tokPos;
                    do {
                        ch = buffer.Read();
                        if (!char.IsHighSurrogate((char)ch)) count++;
                    } while (buffer.Pos < tokEPos && ch != ScanBuff.EndOfFile);
                    buffer.Pos = save;
                    return count;
                }
#endif // BYTEMODE
            }
        }
        
        // ============ methods available in actions ==============

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal int YY_START {
            get { return currentScOrd; }
            set { currentScOrd = value; 
                  currentStart = startState[value]; 
            } 
        }
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void BEGIN(int next) {
            currentScOrd = next;
            currentStart = startState[next];
        }

        // ============== The main tokenizer code =================

        int Scan()
        {
                for (; ; )
                {
                    int next;              // next state to enter                   
#if BACKUP
                    Result rslt = Result.noMatch;
#endif // BACKUP
#if LEFTANCHORS
                    for (;;)
                    {
                        // Discard characters that do not start any pattern.
                        // Must check the left anchor condition after *every* GetCode!
                        state = ((cCol == 0) ? anchorState[currentScOrd] : currentStart);
                        if ((next = NextState()) != goStart) 
                            break; // LOOP EXIT HERE...
                        GetCode();
                    }
                    
#else // !LEFTANCHORS
                    state = currentStart;
                    while ((next = NextState()) == goStart)
                        // At this point, the current character has no
                        // transition from the current state.  We discard 
                        // the "no-match" char.   In traditional LEX such 
                        // characters are echoed to the console.
                        GetCode();
#endif // LEFTANCHORS                    
                    // At last, a valid transition ...    
                    MarkToken();
                    state = next;
                    GetCode();
                    
                    while ((next = NextState()) > eofNum) // Exit for goStart AND for eofNum
#if BACKUP
                        if (state <= maxAccept && next > maxAccept) // need to prepare backup data
                        {
                            // ctx is an object. The fields may be 
                            // mutated by the call to Recurse2.
                            // On return the data in ctx is the
                            // *latest* accept state that was found.
                            
                            rslt = Recurse2(ref ctx, next);
                            if (rslt == Result.noMatch) 
                                RestoreStateAndPos(ref ctx);
                            break;
                        }
                        else
#endif // BACKUP
                        {
                            state = next;
                            GetCode();
                        }
                    if (state <= maxAccept) 
                    {
                        MarkEnd();
#region ActionSwitch
#pragma warning disable 162, 1522
    switch (state)
    {
        case eofNum:
            if (yywrap())
                return (int)ActionToken.EOF;
            break;
        case 1: // Recognized '{dontcare}',	Shortest string "\x01"
colNo++;
            break;
        case 2: // Recognized '{eol}',	Shortest string "\n"
        case 3: // Recognized '{eol}',	Shortest string "\r"
lineNo++; colNo = 0;
            break;
        case 4: // Recognized '\"',	Shortest string "\""
colNo++; BEGIN(LitString);
            break;
        case 5: // Recognized '\'',	Shortest string "'"
colNo++; BEGIN(LitChar);
            break;
        case 6: // Recognized '@{dontcare}',	Shortest string "$\x01"
        case 10: // Recognized '\${dontcare}',	Shortest string "$<"
handler.ListError(ErrSpan(2), 74); colNo += 2;
            break;
        case 7: // Recognized '@\"',	Shortest string "@\""
colNo += 2; BEGIN(VrbString);
            break;
        case 8: // Recognized '@\$',	Shortest string "$$"
colNo += 2;
            break;
        case 9: // Recognized '@{number}',	Shortest string "$0"
CheckLength(yytext); 
                        colNo += yytext.Length;
            break;
        case 11: // Recognized '${kind}{number}',	Shortest string "$<\x01>0"
CheckLengthWithKind(yytext); 
                        colNo += yytext.Length;
            break;
        case 12: // In <LitString> Recognized '.',	Shortest string "\x01"
        case 16: // In <LitString> Recognized '.',	Shortest string "\\"
colNo++;
            break;
        case 13: // In <LitString> Recognized '{eol}',	Shortest string "\n"
        case 14: // In <LitString> Recognized '{eol}',	Shortest string "\r"
handler.ListError(ErrSpan(1), 78);
            break;
        case 15: // In <LitString> Recognized '\"',	Shortest string "\""
colNo++; BEGIN(0);
            break;
        case 17: // In <LitString> Recognized '\\\"',	Shortest string "\\\""
colNo += 2;
            break;
        case 18: // In <VrbString> Recognized '.',	Shortest string "\x01"
colNo++;
            break;
        case 19: // In <VrbString> Recognized '{eol}',	Shortest string "\n"
        case 20: // In <VrbString> Recognized '{eol}',	Shortest string "\r"
lineNo++; colNo = 0;
            break;
        case 21: // In <VrbString> Recognized '\"',	Shortest string "\""
colNo++; BEGIN(0);
            break;
        case 22: // In <VrbString> Recognized '\"\"',	Shortest string "\"\""
colNo += 2;
            break;
        case 23: // In <LitChar> Recognized '.',	Shortest string "\x01"
        case 27: // In <LitChar> Recognized '.',	Shortest string "\\"
colNo++;
            break;
        case 24: // In <LitChar> Recognized '{eol}',	Shortest string "\n"
        case 25: // In <LitChar> Recognized '{eol}',	Shortest string "\r"
handler.ListError(ErrSpan(1), 78);
            break;
        case 26: // In <LitChar> Recognized ''',	Shortest string "'"
colNo++; BEGIN(0);
            break;
        case 28: // In <LitChar> Recognized '\\'',	Shortest string "\\'"
colNo += 2;
            break;
        default:
            break;
    }
#pragma warning restore 162, 1522
#endregion
                    }
                }
        }

#if BACKUP
        Result Recurse2(ref Context ctx, int next)
        {
            // Assert: at entry "state" is an accept state AND
            //         NextState(state, code) != goStart AND
            //         NextState(state, code) is not an accept state.
            //
            SaveStateAndPos(ref ctx);
            state = next;
            GetCode();

            while ((next = NextState()) > eofNum)
            {
                if (state <= maxAccept && next > maxAccept) // need to update backup data
                    SaveStateAndPos(ref ctx);
                state = next;
                if (state == eofNum) return Result.accept;
                GetCode(); 
            }
            return (state <= maxAccept ? Result.accept : Result.noMatch);
        }

        void SaveStateAndPos(ref Context ctx)
        {
            ctx.bPos  = buffer.Pos;
            ctx.rPos  = readPos;
            ctx.cCol  = cCol;
            ctx.lNum  = lNum;
            ctx.state = state;
            ctx.cChr  = code;
        }

        void RestoreStateAndPos(ref Context ctx)
        {
            buffer.Pos = ctx.bPos;
            readPos = ctx.rPos;
            cCol  = ctx.cCol;
            lNum  = ctx.lNum;
            state = ctx.state;
            code  = ctx.cChr;
        }

#endif // BACKUP

        // ============= End of the tokenizer code ================

#if STACK        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void yy_clear_stack() { scStack.Clear(); }
        
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal int yy_top_state() { return scStack.Peek(); }
        
        internal void yy_push_state(int state)
        {
            scStack.Push(currentScOrd);
            BEGIN(state);
        }
        
        internal void yy_pop_state()
        {
            // Protect against input errors that pop too far ...
            if (scStack.Count > 0) {
				int newSc = scStack.Pop();
				BEGIN(newSc);
            } // Otherwise leave stack unchanged.
        }
 #endif // STACK

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal void ECHO() { Console.Out.Write(yytext); }
        
#region UserCodeSection

internal static void CheckSpan(int len, LexSpan span, ErrorHandler hdlr)
    {
        ActionScanner scnr = new ActionScanner();
        scnr.SetSource(span.ToString(), 1);
        scnr.length = len;
        scnr.src = span;
        scnr.handler = hdlr;
        scnr.lineNo = span.startLine;
        scnr.colNo = span.startColumn;
        scnr.yylex();
    }
    
    private void CheckLength(string text)
    {
        int val = int.Parse(text.Substring(1), 0, CultureInfo.InvariantCulture);
        if (val < 1 || val > length)
            handler.ListError(ErrSpan(text.Length), 73);
    }
    
    private void CheckLengthWithKind(string text)
    {
        int endKind = text.LastIndexOf('>');
        int val = int.Parse(text.Substring(endKind + 1), 0, CultureInfo.InvariantCulture);
        if (val < 1 || val > length)
            handler.ListError(ErrSpan(text.Length), 73);
    }
    
    private LexSpan ErrSpan(int len)
    {
        return new LexSpan(lineNo, colNo, lineNo, colNo+len, src.startIndex, src.endIndex, src.buffer);
    }

#endregion
    } // end class $Scanner


} // end namespace
