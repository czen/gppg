// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, QUT 2005-2010
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.0
// Machine:  LKCZXVZ
// DateTime: 3/25/2013 4:11:30 PM
// UserName: ellingsd
// Input file <gppg.y - 1/3/2013 3:11:03 PM>

// options: no-lines gplex

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using System.Collections;

namespace QUT.GPGen.Parser
{
internal enum Token {error=126,
    EOF=127,codeStart=128,codeEnd=129,ident=130,anchoredSymbol=131,number=132,
    filePath=133,litstring=134,verbatim=135,litchar=136,kwPCPC=137,kwLbrace=138,
    kwRbrace=139,kwToken=140,kwType=141,kwLeft=142,kwRight=143,kwNonassoc=144,
    kwPrec=145,kwStart=146,kwUnion=147,kwDefines=148,kwLocations=149,kwNamespace=150,
    kwPartial=151,kwOutput=152,kwShareTokens=153,kwImportTokens=154,kwParsertype=155,kwTokentype=156,
    kwScanbasetype=157,kwUsing=158,kwVisibility=159,kwYYSTYPE=160,kwYYLTYPE=161,maxParseToken=162,
    errTok=163};

internal partial struct ValueType
{ public int iVal; 
         public List<string> stringList;
         public List<TokenInfo> tokenList;
         public TokenInfo tokenInfo; 
         public Production prod;
         public ActionProxy proxy;
       }
// Abstract base class for GPLEX scanners
internal abstract class ScanBase : AbstractScanner<ValueType,LexSpan> {
  private LexSpan __yylloc = new LexSpan();
  public override LexSpan yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
internal class ScanObj {
  public int token;
  public ValueType yylval;
  public LexSpan yylloc;
  public ScanObj( int t, ValueType val, LexSpan loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

internal partial class Parser: ShiftReduceParser<ValueType, LexSpan>
{
  // Verbatim content from gppg.y - 1/3/2013 3:11:03 PM
/*
 *  Parser spec for GPPG
 *  gppg.y: Author: John Gough, August 2008
 *  Process with > GPPG /gplex /no-lines gppg.y
 */
  // End verbatim content from gppg.y - 1/3/2013 3:11:03 PM

#pragma warning disable 649
  private static Dictionary<int, string> aliasses;
#pragma warning restore 649
  private static Rule[] rules = new Rule[114];
  private static State[] states = new State[161];
  private static string[] nonTerms = new string[] {
      "TokenList", "TokenDecl", "NtSymbolList", "Symbols", "SymbolsOpt", "RightHandSide", 
      "RHStermList", "Action", "PrecOptAndAction", "Program", "$accept", "DefinitionSectionOpt", 
      "Divider", "RulesSection", "EpilogOpt", "CodeBlock", "Definitions", "Definition", 
      "Declaration", "KindOpt", "Kind", "NtSymbol", "TypeNameOpt", "UnionTypeConstructor", 
      "DottedName", "SemiOpt", "TypeConstructor", "CommaOpt", "BadSeparator", 
      "TypeArguments", "DeclList", "OneDecl", "TypeConstructorSeq", "ARule", 
      "RuleProlog", "AlternativesOpt", "SymOrLit", };

  static Parser() {
    states[0] = new State(new int[]{138,46,140,50,141,79,142,88,143,91,144,94,146,97,147,99,149,126,148,127,151,128,153,129,154,130,150,135,158,137,152,141,157,146,155,148,159,150,156,152,160,154,161,156,126,159,137,-11},new int[]{-10,1,-12,3,-17,44,-18,158,-19,49});
    states[1] = new State(new int[]{127,2});
    states[2] = new State(-1);
    states[3] = new State(new int[]{137,43},new int[]{-13,4});
    states[4] = new State(new int[]{131,39,126,42},new int[]{-14,5,-34,41,-35,13});
    states[5] = new State(new int[]{137,8,131,39,127,-6},new int[]{-15,6,-34,7,-35,13});
    states[6] = new State(-2);
    states[7] = new State(-90);
    states[8] = new State(new int[]{128,10,127,-8},new int[]{-16,9});
    states[9] = new State(-5);
    states[10] = new State(new int[]{129,11,126,12});
    states[11] = new State(-7);
    states[12] = new State(-9);
    states[13] = new State(new int[]{130,24,136,25,134,26,123,29,145,33,59,-97,124,-97},new int[]{-6,14,-7,19,-4,36,-37,27,-9,37,-8,28});
    states[14] = new State(-95,new int[]{-36,15});
    states[15] = new State(new int[]{59,16,124,17});
    states[16] = new State(-93);
    states[17] = new State(new int[]{130,24,136,25,134,26,123,29,145,33,59,-97,124,-97},new int[]{-6,18,-7,19,-4,36,-37,27,-9,37,-8,28});
    states[18] = new State(-96);
    states[19] = new State(new int[]{123,29,145,33,59,-98,124,-98},new int[]{-9,20,-8,28});
    states[20] = new State(new int[]{130,24,136,25,134,26,123,-102,145,-102,59,-102,124,-102},new int[]{-5,21,-4,22,-37,27});
    states[21] = new State(-101);
    states[22] = new State(new int[]{130,24,136,25,134,26,123,-103,145,-103,59,-103,124,-103},new int[]{-37,23});
    states[23] = new State(-105);
    states[24] = new State(-106);
    states[25] = new State(-107);
    states[26] = new State(-108);
    states[27] = new State(-104);
    states[28] = new State(-109);
    states[29] = new State(new int[]{128,10,125,-8,126,-8},new int[]{-16,30});
    states[30] = new State(new int[]{125,31,126,32});
    states[31] = new State(-112);
    states[32] = new State(-113);
    states[33] = new State(new int[]{130,34});
    states[34] = new State(new int[]{123,29,130,-111,136,-111,134,-111,145,-111,59,-111,124,-111},new int[]{-8,35});
    states[35] = new State(-110);
    states[36] = new State(new int[]{130,24,136,25,134,26,123,-99,145,-99,59,-99,124,-99},new int[]{-37,23});
    states[37] = new State(new int[]{130,24,136,25,134,26,123,-102,145,-102,59,-102,124,-102},new int[]{-5,38,-4,22,-37,27});
    states[38] = new State(-100);
    states[39] = new State(new int[]{58,40});
    states[40] = new State(-94);
    states[41] = new State(-91);
    states[42] = new State(-92);
    states[43] = new State(-4);
    states[44] = new State(new int[]{138,46,140,50,141,79,142,88,143,91,144,94,146,97,147,99,149,126,148,127,151,128,153,129,154,130,150,135,158,137,152,141,157,146,155,148,159,150,156,152,160,154,161,156,137,-10},new int[]{-18,45,-19,49});
    states[45] = new State(-13);
    states[46] = new State(new int[]{128,10,139,-8},new int[]{-16,47});
    states[47] = new State(new int[]{139,48});
    states[48] = new State(-16);
    states[49] = new State(-17);
    states[50] = new State(new int[]{60,74,130,-48,136,-48},new int[]{-20,51,-21,73});
    states[51] = new State(new int[]{130,55,136,59},new int[]{-1,52,-2,72});
    states[52] = new State(new int[]{44,61,59,62,58,63,60,64,62,65,40,66,41,67,91,68,93,69,123,70,125,71,138,-18,140,-18,141,-18,142,-18,143,-18,144,-18,146,-18,147,-18,149,-18,148,-18,151,-18,153,-18,154,-18,150,-18,158,-18,152,-18,157,-18,155,-18,159,-18,156,-18,160,-18,161,-18,137,-18,130,-77,136,-77},new int[]{-28,53,-29,60});
    states[53] = new State(new int[]{130,55,136,59},new int[]{-2,54});
    states[54] = new State(-52);
    states[55] = new State(new int[]{132,56,134,57,44,-56,59,-56,58,-56,60,-56,62,-56,40,-56,41,-56,91,-56,93,-56,123,-56,125,-56,130,-56,136,-56,138,-56,140,-56,141,-56,142,-56,143,-56,144,-56,146,-56,147,-56,149,-56,148,-56,151,-56,153,-56,154,-56,150,-56,158,-56,152,-56,157,-56,155,-56,159,-56,156,-56,160,-56,161,-56,137,-56});
    states[56] = new State(-54);
    states[57] = new State(new int[]{132,58,44,-57,59,-57,58,-57,60,-57,62,-57,40,-57,41,-57,91,-57,93,-57,123,-57,125,-57,130,-57,136,-57,138,-57,140,-57,141,-57,142,-57,143,-57,144,-57,146,-57,147,-57,149,-57,148,-57,151,-57,153,-57,154,-57,150,-57,158,-57,152,-57,157,-57,155,-57,159,-57,156,-57,160,-57,161,-57,137,-57});
    states[58] = new State(-55);
    states[59] = new State(-58);
    states[60] = new State(-53);
    states[61] = new State(-76);
    states[62] = new State(-80);
    states[63] = new State(-81);
    states[64] = new State(-82);
    states[65] = new State(-83);
    states[66] = new State(-84);
    states[67] = new State(-85);
    states[68] = new State(-86);
    states[69] = new State(-87);
    states[70] = new State(-88);
    states[71] = new State(-89);
    states[72] = new State(-51);
    states[73] = new State(-47);
    states[74] = new State(new int[]{130,75,126,77});
    states[75] = new State(new int[]{62,76});
    states[76] = new State(-49);
    states[77] = new State(new int[]{62,78});
    states[78] = new State(-50);
    states[79] = new State(new int[]{60,74},new int[]{-21,80});
    states[80] = new State(new int[]{130,84,131,85},new int[]{-3,81,-22,87});
    states[81] = new State(new int[]{44,61,59,62,58,63,60,64,62,65,40,66,41,67,91,68,93,69,123,70,125,71,138,-19,140,-19,141,-19,142,-19,143,-19,144,-19,146,-19,147,-19,149,-19,148,-19,151,-19,153,-19,154,-19,150,-19,158,-19,152,-19,157,-19,155,-19,159,-19,156,-19,160,-19,161,-19,137,-19,130,-77,131,-77},new int[]{-28,82,-29,86});
    states[82] = new State(new int[]{130,84,131,85},new int[]{-22,83});
    states[83] = new State(-60);
    states[84] = new State(-62);
    states[85] = new State(-63);
    states[86] = new State(-61);
    states[87] = new State(-59);
    states[88] = new State(new int[]{60,74,130,-48,136,-48},new int[]{-20,89,-21,73});
    states[89] = new State(new int[]{130,55,136,59},new int[]{-1,90,-2,72});
    states[90] = new State(new int[]{44,61,59,62,58,63,60,64,62,65,40,66,41,67,91,68,93,69,123,70,125,71,138,-20,140,-20,141,-20,142,-20,143,-20,144,-20,146,-20,147,-20,149,-20,148,-20,151,-20,153,-20,154,-20,150,-20,158,-20,152,-20,157,-20,155,-20,159,-20,156,-20,160,-20,161,-20,137,-20,130,-77,136,-77},new int[]{-28,53,-29,60});
    states[91] = new State(new int[]{60,74,130,-48,136,-48},new int[]{-20,92,-21,73});
    states[92] = new State(new int[]{130,55,136,59},new int[]{-1,93,-2,72});
    states[93] = new State(new int[]{44,61,59,62,58,63,60,64,62,65,40,66,41,67,91,68,93,69,123,70,125,71,138,-21,140,-21,141,-21,142,-21,143,-21,144,-21,146,-21,147,-21,149,-21,148,-21,151,-21,153,-21,154,-21,150,-21,158,-21,152,-21,157,-21,155,-21,159,-21,156,-21,160,-21,161,-21,137,-21,130,-77,136,-77},new int[]{-28,53,-29,60});
    states[94] = new State(new int[]{60,74,130,-48,136,-48},new int[]{-20,95,-21,73});
    states[95] = new State(new int[]{130,55,136,59},new int[]{-1,96,-2,72});
    states[96] = new State(new int[]{44,61,59,62,58,63,60,64,62,65,40,66,41,67,91,68,93,69,123,70,125,71,138,-22,140,-22,141,-22,142,-22,143,-22,144,-22,146,-22,147,-22,149,-22,148,-22,151,-22,153,-22,154,-22,150,-22,158,-22,152,-22,157,-22,155,-22,159,-22,156,-22,160,-22,161,-22,137,-22,130,-77,136,-77},new int[]{-28,53,-29,60});
    states[97] = new State(new int[]{130,84,131,85},new int[]{-22,98});
    states[98] = new State(-23);
    states[99] = new State(new int[]{130,125,123,-44},new int[]{-23,100});
    states[100] = new State(new int[]{123,102},new int[]{-24,101});
    states[101] = new State(-24);
    states[102] = new State(new int[]{130,120,126,124},new int[]{-31,103,-32,123,-33,106,-27,122,-25,110});
    states[103] = new State(new int[]{125,104,130,120},new int[]{-32,105,-33,106,-27,122,-25,110});
    states[104] = new State(-69);
    states[105] = new State(-71);
    states[106] = new State(new int[]{130,107},new int[]{-27,109,-25,110});
    states[107] = new State(new int[]{59,108,91,-46,46,-46,60,-46,130,-46});
    states[108] = new State(-73);
    states[109] = new State(-75);
    states[110] = new State(new int[]{91,111,46,113,60,115,130,-66,62,-66,44,-66,138,-66,140,-66,141,-66,142,-66,143,-66,144,-66,146,-66,147,-66,149,-66,148,-66,151,-66,153,-66,154,-66,150,-66,158,-66,152,-66,157,-66,155,-66,159,-66,156,-66,160,-66,161,-66,137,-66});
    states[111] = new State(new int[]{93,112});
    states[112] = new State(-64);
    states[113] = new State(new int[]{130,114});
    states[114] = new State(-45);
    states[115] = new State(new int[]{130,120},new int[]{-30,116,-27,121,-25,110});
    states[116] = new State(new int[]{62,117,44,118});
    states[117] = new State(-65);
    states[118] = new State(new int[]{130,120},new int[]{-27,119,-25,110});
    states[119] = new State(-68);
    states[120] = new State(-46);
    states[121] = new State(-67);
    states[122] = new State(-74);
    states[123] = new State(-70);
    states[124] = new State(-72);
    states[125] = new State(-43);
    states[126] = new State(-25);
    states[127] = new State(-26);
    states[128] = new State(-27);
    states[129] = new State(-28);
    states[130] = new State(new int[]{61,131});
    states[131] = new State(new int[]{133,132,134,133,135,134});
    states[132] = new State(-29);
    states[133] = new State(-30);
    states[134] = new State(-31);
    states[135] = new State(new int[]{130,120},new int[]{-25,136});
    states[136] = new State(new int[]{46,113,138,-32,140,-32,141,-32,142,-32,143,-32,144,-32,146,-32,147,-32,149,-32,148,-32,151,-32,153,-32,154,-32,150,-32,158,-32,152,-32,157,-32,155,-32,159,-32,156,-32,160,-32,161,-32,137,-32});
    states[137] = new State(new int[]{130,120},new int[]{-25,138});
    states[138] = new State(new int[]{46,113,59,140,138,-79,140,-79,141,-79,142,-79,143,-79,144,-79,146,-79,147,-79,149,-79,148,-79,151,-79,153,-79,154,-79,150,-79,158,-79,152,-79,157,-79,155,-79,159,-79,156,-79,160,-79,161,-79,137,-79},new int[]{-26,139});
    states[139] = new State(-33);
    states[140] = new State(-78);
    states[141] = new State(new int[]{61,142});
    states[142] = new State(new int[]{133,143,134,144,135,145});
    states[143] = new State(-34);
    states[144] = new State(-35);
    states[145] = new State(-36);
    states[146] = new State(new int[]{130,147});
    states[147] = new State(-37);
    states[148] = new State(new int[]{130,149});
    states[149] = new State(-38);
    states[150] = new State(new int[]{130,151});
    states[151] = new State(-39);
    states[152] = new State(new int[]{130,153});
    states[153] = new State(-40);
    states[154] = new State(new int[]{130,120},new int[]{-27,155,-25,110});
    states[155] = new State(-41);
    states[156] = new State(new int[]{130,120},new int[]{-27,157,-25,110});
    states[157] = new State(-42);
    states[158] = new State(-14);
    states[159] = new State(new int[]{138,46,140,50,141,79,142,88,143,91,144,94,146,97,147,99,149,126,148,127,151,128,153,129,154,130,150,135,158,137,152,141,157,146,155,148,159,150,156,152,160,154,161,156,137,-12,127,-3},new int[]{-18,160,-19,49});
    states[160] = new State(-15);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-11, new int[]{-10,127});
    rules[2] = new Rule(-10, new int[]{-12,-13,-14,-15});
    rules[3] = new Rule(-10, new int[]{126});
    rules[4] = new Rule(-13, new int[]{137});
    rules[5] = new Rule(-15, new int[]{137,-16});
    rules[6] = new Rule(-15, new int[]{});
    rules[7] = new Rule(-16, new int[]{128,129});
    rules[8] = new Rule(-16, new int[]{});
    rules[9] = new Rule(-16, new int[]{128,126});
    rules[10] = new Rule(-12, new int[]{-17});
    rules[11] = new Rule(-12, new int[]{});
    rules[12] = new Rule(-12, new int[]{126});
    rules[13] = new Rule(-17, new int[]{-17,-18});
    rules[14] = new Rule(-17, new int[]{-18});
    rules[15] = new Rule(-17, new int[]{126,-18});
    rules[16] = new Rule(-18, new int[]{138,-16,139});
    rules[17] = new Rule(-18, new int[]{-19});
    rules[18] = new Rule(-19, new int[]{140,-20,-1});
    rules[19] = new Rule(-19, new int[]{141,-21,-3});
    rules[20] = new Rule(-19, new int[]{142,-20,-1});
    rules[21] = new Rule(-19, new int[]{143,-20,-1});
    rules[22] = new Rule(-19, new int[]{144,-20,-1});
    rules[23] = new Rule(-19, new int[]{146,-22});
    rules[24] = new Rule(-19, new int[]{147,-23,-24});
    rules[25] = new Rule(-19, new int[]{149});
    rules[26] = new Rule(-19, new int[]{148});
    rules[27] = new Rule(-19, new int[]{151});
    rules[28] = new Rule(-19, new int[]{153});
    rules[29] = new Rule(-19, new int[]{154,61,133});
    rules[30] = new Rule(-19, new int[]{154,61,134});
    rules[31] = new Rule(-19, new int[]{154,61,135});
    rules[32] = new Rule(-19, new int[]{150,-25});
    rules[33] = new Rule(-19, new int[]{158,-25,-26});
    rules[34] = new Rule(-19, new int[]{152,61,133});
    rules[35] = new Rule(-19, new int[]{152,61,134});
    rules[36] = new Rule(-19, new int[]{152,61,135});
    rules[37] = new Rule(-19, new int[]{157,130});
    rules[38] = new Rule(-19, new int[]{155,130});
    rules[39] = new Rule(-19, new int[]{159,130});
    rules[40] = new Rule(-19, new int[]{156,130});
    rules[41] = new Rule(-19, new int[]{160,-27});
    rules[42] = new Rule(-19, new int[]{161,-27});
    rules[43] = new Rule(-23, new int[]{130});
    rules[44] = new Rule(-23, new int[]{});
    rules[45] = new Rule(-25, new int[]{-25,46,130});
    rules[46] = new Rule(-25, new int[]{130});
    rules[47] = new Rule(-20, new int[]{-21});
    rules[48] = new Rule(-20, new int[]{});
    rules[49] = new Rule(-21, new int[]{60,130,62});
    rules[50] = new Rule(-21, new int[]{60,126,62});
    rules[51] = new Rule(-1, new int[]{-2});
    rules[52] = new Rule(-1, new int[]{-1,-28,-2});
    rules[53] = new Rule(-1, new int[]{-1,-29});
    rules[54] = new Rule(-2, new int[]{130,132});
    rules[55] = new Rule(-2, new int[]{130,134,132});
    rules[56] = new Rule(-2, new int[]{130});
    rules[57] = new Rule(-2, new int[]{130,134});
    rules[58] = new Rule(-2, new int[]{136});
    rules[59] = new Rule(-3, new int[]{-22});
    rules[60] = new Rule(-3, new int[]{-3,-28,-22});
    rules[61] = new Rule(-3, new int[]{-3,-29});
    rules[62] = new Rule(-22, new int[]{130});
    rules[63] = new Rule(-22, new int[]{131});
    rules[64] = new Rule(-27, new int[]{-25,91,93});
    rules[65] = new Rule(-27, new int[]{-25,60,-30,62});
    rules[66] = new Rule(-27, new int[]{-25});
    rules[67] = new Rule(-30, new int[]{-27});
    rules[68] = new Rule(-30, new int[]{-30,44,-27});
    rules[69] = new Rule(-24, new int[]{123,-31,125});
    rules[70] = new Rule(-31, new int[]{-32});
    rules[71] = new Rule(-31, new int[]{-31,-32});
    rules[72] = new Rule(-31, new int[]{126});
    rules[73] = new Rule(-32, new int[]{-33,130,59});
    rules[74] = new Rule(-33, new int[]{-27});
    rules[75] = new Rule(-33, new int[]{-33,-27});
    rules[76] = new Rule(-28, new int[]{44});
    rules[77] = new Rule(-28, new int[]{});
    rules[78] = new Rule(-26, new int[]{59});
    rules[79] = new Rule(-26, new int[]{});
    rules[80] = new Rule(-29, new int[]{59});
    rules[81] = new Rule(-29, new int[]{58});
    rules[82] = new Rule(-29, new int[]{60});
    rules[83] = new Rule(-29, new int[]{62});
    rules[84] = new Rule(-29, new int[]{40});
    rules[85] = new Rule(-29, new int[]{41});
    rules[86] = new Rule(-29, new int[]{91});
    rules[87] = new Rule(-29, new int[]{93});
    rules[88] = new Rule(-29, new int[]{123});
    rules[89] = new Rule(-29, new int[]{125});
    rules[90] = new Rule(-14, new int[]{-14,-34});
    rules[91] = new Rule(-14, new int[]{-34});
    rules[92] = new Rule(-14, new int[]{126});
    rules[93] = new Rule(-34, new int[]{-35,-6,-36,59});
    rules[94] = new Rule(-35, new int[]{131,58});
    rules[95] = new Rule(-36, new int[]{});
    rules[96] = new Rule(-36, new int[]{-36,124,-6});
    rules[97] = new Rule(-6, new int[]{});
    rules[98] = new Rule(-6, new int[]{-7});
    rules[99] = new Rule(-7, new int[]{-4});
    rules[100] = new Rule(-7, new int[]{-9,-5});
    rules[101] = new Rule(-7, new int[]{-7,-9,-5});
    rules[102] = new Rule(-5, new int[]{});
    rules[103] = new Rule(-5, new int[]{-4});
    rules[104] = new Rule(-4, new int[]{-37});
    rules[105] = new Rule(-4, new int[]{-4,-37});
    rules[106] = new Rule(-37, new int[]{130});
    rules[107] = new Rule(-37, new int[]{136});
    rules[108] = new Rule(-37, new int[]{134});
    rules[109] = new Rule(-9, new int[]{-8});
    rules[110] = new Rule(-9, new int[]{145,130,-8});
    rules[111] = new Rule(-9, new int[]{145,130});
    rules[112] = new Rule(-8, new int[]{123,-16,125});
    rules[113] = new Rule(-8, new int[]{123,-16,126});

    aliasses = new Dictionary<int, string>();
    aliasses.Add(137, "\"%%\"");
    aliasses.Add(138, "\"%{\"");
    aliasses.Add(139, "\"%}\"");
    aliasses.Add(140, "\"%token\"");
    aliasses.Add(141, "\"%type\"");
    aliasses.Add(142, "\"%left\"");
    aliasses.Add(143, "\"%right\"");
    aliasses.Add(144, "\"%nonassoc\"");
    aliasses.Add(145, "\"%prec\"");
    aliasses.Add(146, "\"%start\"");
    aliasses.Add(147, "\"%union\"");
    aliasses.Add(148, "\"%defines\"");
    aliasses.Add(149, "\"%locations\"");
    aliasses.Add(150, "\"%namespace\"");
    aliasses.Add(151, "\"%partial\"");
    aliasses.Add(152, "\"%output\"");
    aliasses.Add(153, "\"%sharetokens\"");
    aliasses.Add(154, "\"%importtokens\"");
    aliasses.Add(155, "\"%parsertype\"");
    aliasses.Add(156, "\"%tokentype\"");
    aliasses.Add(157, "\"%scanbasetype\"");
    aliasses.Add(158, "\"%using\"");
    aliasses.Add(159, "\"%visibility\"");
    aliasses.Add(160, "\"%YYSTYPE\"");
    aliasses.Add(161, "\"%YYLTYPE\"");
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Token.error, (int)Token.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 4: // Divider -> "%%"
{ TidyUpDefinitions(LocationStack[LocationStack.Depth-1]); }
        break;
      case 5: // EpilogOpt -> "%%", CodeBlock
{ grammar.epilogCode = LocationStack[LocationStack.Depth-1]; }
        break;
      case 7: // CodeBlock -> codeStart, codeEnd
{ /* default location action @$ = @1.Merge(@2); */ }
        break;
      case 9: // CodeBlock -> codeStart, error
{ handler.ListError(LocationStack[LocationStack.Depth-2], 77); }
        break;
      case 16: // Definition -> "%{", CodeBlock, "%}"
{ grammar.prologCode.Add(LocationStack[LocationStack.Depth-2]); }
        break;
      case 18: // Declaration -> "%token", KindOpt, TokenList
{ DeclareTokens(LocationStack[LocationStack.Depth-3], PrecType.token, LocationStack[LocationStack.Depth-2].ToString(), ValueStack[ValueStack.Depth-1].tokenList); }
        break;
      case 19: // Declaration -> "%type", Kind, NtSymbolList
{
						  string kind = LocationStack[LocationStack.Depth-2].ToString();
						  DeclareNtKind(kind, ValueStack[ValueStack.Depth-1].stringList);
						}
        break;
      case 20: // Declaration -> "%left", KindOpt, TokenList
{ DeclareTokens(LocationStack[LocationStack.Depth-3], PrecType.left, LocationStack[LocationStack.Depth-2].ToString(), ValueStack[ValueStack.Depth-1].tokenList); }
        break;
      case 21: // Declaration -> "%right", KindOpt, TokenList
{ DeclareTokens(LocationStack[LocationStack.Depth-3], PrecType.right, LocationStack[LocationStack.Depth-2].ToString(), ValueStack[ValueStack.Depth-1].tokenList); }
        break;
      case 22: // Declaration -> "%nonassoc", KindOpt, TokenList
{ DeclareTokens(LocationStack[LocationStack.Depth-3], PrecType.nonassoc, LocationStack[LocationStack.Depth-2].ToString(), ValueStack[ValueStack.Depth-1].tokenList); }
        break;
      case 23: // Declaration -> "%start", NtSymbol
{ grammar.startSymbol = grammar.LookupNonTerminal(LocationStack[LocationStack.Depth-1].ToString()); }
        break;
      case 24: // Declaration -> "%union", TypeNameOpt, UnionTypeConstructor
{ grammar.unionType = LocationStack[LocationStack.Depth-1]; }
        break;
      case 25: // Declaration -> "%locations"
{ handler.ListError(LocationStack[LocationStack.Depth-1], 101); }
        break;
      case 26: // Declaration -> "%defines"
{ GPCG.Defines = true; }
        break;
      case 27: // Declaration -> "%partial"
{ grammar.IsPartial = true; }
        break;
      case 28: // Declaration -> "%sharetokens"
{ GPCG.ShareTokens = true; }
        break;
      case 29: // Declaration -> "%importtokens", '=', filePath
{ GPCG.ImportedTokens = true;
						  grammar.DatFileName = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 30: // Declaration -> "%importtokens", '=', litstring
{ GPCG.ImportedTokens = true;
						  grammar.DatFileName = GetLitString(LocationStack[LocationStack.Depth-1]); }
        break;
      case 31: // Declaration -> "%importtokens", '=', verbatim
{ GPCG.ImportedTokens = true;
						  grammar.DatFileName = GetVerbatimString(LocationStack[LocationStack.Depth-1]); }
        break;
      case 32: // Declaration -> "%namespace", DottedName
{ grammar.Namespace = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 33: // Declaration -> "%using", DottedName, SemiOpt
{ grammar.usingList.Add(LocationStack[LocationStack.Depth-2].ToString()); }
        break;
      case 34: // Declaration -> "%output", '=', filePath
{ grammar.OutFileName = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 35: // Declaration -> "%output", '=', litstring
{ grammar.OutFileName = GetLitString(LocationStack[LocationStack.Depth-1]); }
        break;
      case 36: // Declaration -> "%output", '=', verbatim
{ grammar.OutFileName = GetVerbatimString(LocationStack[LocationStack.Depth-1]); }
        break;
      case 37: // Declaration -> "%scanbasetype", ident
{ grammar.ScanBaseName = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 38: // Declaration -> "%parsertype", ident
{ grammar.ParserName = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 39: // Declaration -> "%visibility", ident
{ grammar.Visibility = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 40: // Declaration -> "%tokentype", ident
{ grammar.TokenName = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 41: // Declaration -> "%YYSTYPE", TypeConstructor
{ SetSemanticType(LocationStack[LocationStack.Depth-1]); }
        break;
      case 42: // Declaration -> "%YYLTYPE", TypeConstructor
{ grammar.LocationTypeName = LocationStack[LocationStack.Depth-1].ToString(); }
        break;
      case 43: // TypeNameOpt -> ident
{ SetSemanticType(LocationStack[LocationStack.Depth-1]); }
        break;
      case 49: // Kind -> '<', ident, '>'
{ CurrentLocationSpan = LocationStack[LocationStack.Depth-2]; }
        break;
      case 51: // TokenList -> TokenDecl
{
                          CurrentSemanticValue.tokenList = new List<TokenInfo>();
                          CurrentSemanticValue.tokenList.Add(ValueStack[ValueStack.Depth-1].tokenInfo);
                        }
        break;
      case 52: // TokenList -> TokenList, CommaOpt, TokenDecl
{ ValueStack[ValueStack.Depth-3].tokenList.Add(ValueStack[ValueStack.Depth-1].tokenInfo); CurrentSemanticValue.tokenList = ValueStack[ValueStack.Depth-3].tokenList;}
        break;
      case 53: // TokenList -> TokenList, BadSeparator
{ handler.ListError(LocationStack[LocationStack.Depth-1], 75); CurrentSemanticValue.tokenList = ValueStack[ValueStack.Depth-2].tokenList; }
        break;
      case 54: // TokenDecl -> ident, number
{ 
                          handler.ListError(LocationStack[LocationStack.Depth-1], 100); 
                          CurrentSemanticValue.tokenInfo = new TokenInfo(LocationStack[LocationStack.Depth-2], null);
                        }
        break;
      case 55: // TokenDecl -> ident, litstring, number
{ 
                          handler.ListError(LocationStack[LocationStack.Depth-2], 100); 
                          CurrentSemanticValue.tokenInfo = new TokenInfo(LocationStack[LocationStack.Depth-3], LocationStack[LocationStack.Depth-2]);
                        }
        break;
      case 56: // TokenDecl -> ident
{ CurrentSemanticValue.tokenInfo = new TokenInfo(LocationStack[LocationStack.Depth-1], null); }
        break;
      case 57: // TokenDecl -> ident, litstring
{ CurrentSemanticValue.tokenInfo = new TokenInfo(LocationStack[LocationStack.Depth-2], LocationStack[LocationStack.Depth-1]); }
        break;
      case 58: // TokenDecl -> litchar
{ CurrentSemanticValue.tokenInfo = new TokenInfo(LocationStack[LocationStack.Depth-1], null); }
        break;
      case 59: // NtSymbolList -> NtSymbol
{ 
                          CurrentSemanticValue.stringList = new List<string>();
						  CurrentSemanticValue.stringList.Add(LocationStack[LocationStack.Depth-1].ToString()); 
						}
        break;
      case 60: // NtSymbolList -> NtSymbolList, CommaOpt, NtSymbol
{ ValueStack[ValueStack.Depth-3].stringList.Add(LocationStack[LocationStack.Depth-1].ToString()); CurrentSemanticValue.stringList = ValueStack[ValueStack.Depth-3].stringList; }
        break;
      case 61: // NtSymbolList -> NtSymbolList, BadSeparator
{ handler.ListError(LocationStack[LocationStack.Depth-1], 75); CurrentSemanticValue.stringList = ValueStack[ValueStack.Depth-2].stringList; }
        break;
      case 93: // ARule -> RuleProlog, RightHandSide, AlternativesOpt, ';'
{ ClearCurrentLHS(); }
        break;
      case 94: // RuleProlog -> anchoredSymbol, ':'
{ SetCurrentLHS(LocationStack[LocationStack.Depth-2]); }
        break;
      case 97: // RightHandSide -> /* empty */
{ CurrentSemanticValue.prod = NewProduction(); FinalizeProduction(CurrentSemanticValue.prod); }
        break;
      case 98: // RightHandSide -> RHStermList
{ CurrentSemanticValue.prod = ValueStack[ValueStack.Depth-1].prod; FinalizeProduction(CurrentSemanticValue.prod); }
        break;
      case 99: // RHStermList -> Symbols
{ CurrentSemanticValue.prod = NewProduction(ValueStack[ValueStack.Depth-1].stringList, null); }
        break;
      case 100: // RHStermList -> PrecOptAndAction, SymbolsOpt
{
                          CurrentSemanticValue.prod = NewProduction(null, ValueStack[ValueStack.Depth-2].proxy);
                          AddSymbolsToProduction(CurrentSemanticValue.prod, ValueStack[ValueStack.Depth-1].stringList);
                        }
        break;
      case 101: // RHStermList -> RHStermList, PrecOptAndAction, SymbolsOpt
{
                          AddActionToProduction(ValueStack[ValueStack.Depth-3].prod, ValueStack[ValueStack.Depth-2].proxy);
                          AddSymbolsToProduction(ValueStack[ValueStack.Depth-3].prod, ValueStack[ValueStack.Depth-1].stringList);
                          CurrentSemanticValue.prod = ValueStack[ValueStack.Depth-3].prod;
                        }
        break;
      case 102: // SymbolsOpt -> /* empty */
{ CurrentSemanticValue.stringList = null; }
        break;
      case 104: // Symbols -> SymOrLit
{ CurrentSemanticValue.stringList = new List<string>(); CurrentSemanticValue.stringList.Add(LocationStack[LocationStack.Depth-1].ToString()); }
        break;
      case 105: // Symbols -> Symbols, SymOrLit
{ ValueStack[ValueStack.Depth-2].stringList.Add(LocationStack[LocationStack.Depth-1].ToString());  CurrentSemanticValue.stringList = ValueStack[ValueStack.Depth-2].stringList; }
        break;
      case 109: // PrecOptAndAction -> Action
{ CurrentSemanticValue.proxy = ValueStack[ValueStack.Depth-1].proxy; }
        break;
      case 110: // PrecOptAndAction -> "%prec", ident, Action
{ ValueStack[ValueStack.Depth-1].proxy.precedenceToken = LocationStack[LocationStack.Depth-2]; ValueStack[ValueStack.Depth-1].proxy.precedenceSpan = LocationStack[LocationStack.Depth-3]; CurrentSemanticValue.proxy = ValueStack[ValueStack.Depth-1].proxy; }
        break;
      case 111: // PrecOptAndAction -> "%prec", ident
{ CurrentSemanticValue.proxy = new ActionProxy(LocationStack[LocationStack.Depth-2], LocationStack[LocationStack.Depth-1], null); }
        break;
      case 112: // Action -> '{', CodeBlock, '}'
{ CurrentSemanticValue.proxy = new ActionProxy(null, null, CurrentLocationSpan); }
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliasses != null && aliasses.ContainsKey(terminal))
        return aliasses[terminal];
    else if (((Token)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Token)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

}
}
