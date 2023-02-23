grammar Jade;

/* Jade Lexer */
LPAREN: '(';
RPAREN: ')';
LBRACE: '{';
RBRACE: '}';
LLIST: '[';
RLIST: ']';
ASSIGN: '=';
DOT: '.';
COMMA: ',';
COLON: ':';
SEMI: ';';
LARROW: '->';
RARROW: '<-';
ARROWASSIGN: '=>';
QUESTION: '?';

// Operators
OPERATOR: '+' | '-' | '*' | '/' | '%' | '&&' | '||' | '==' | '!=' | '~=' | '>' | '<' | '>=' | '<='
           | 'and' | 'or' | '**';
OPERATOR2: '!' | 'not';

/// Keywords
FUNC: 'func';
IF: 'if';
ELSE: 'else';
WHILE: 'while';
IMPORT: 'import';
FROM: 'from';
OVERRIDE: 'override';
NEW: 'new';
CLASS: 'class';
PUBLIC: 'public';
PRIVATE: 'private';
RETURN: 'return';
BREAK: 'break';
CONTINUE: 'continue';
REPEAT: 'repeat';
UNTIL: 'until';
UNDEFINE: 'undefine';
TRY: 'try';
CATCH: 'catch';
SWITCH: 'switch';
CASE: 'case';
DEFAULT: 'default';
CONST: 'const';

/// Data type Keywords
KW_STRING: 'string';
KW_INT: 'int';
KW_FLOAT: 'float';
KW_BOOL: 'bool';
KW_ARRAY: 'array';

ALL_KWS: KW_STRING | KW_INT | KW_FLOAT | KW_BOOL;

/// Skipped Rules
COMMENT: ('//' | '<--' | '#') ~[\r\n]* -> skip;
WS: [ \t\r\n] -> skip;
MULTILINECOMMENT: '/*' .*? '*/' -> skip;

/// Data Types
BOOL: ('true' | 'false');
NUL: 'null';

HEXITEM : [0-9a-zA-Z_];
HEX: '0x' HEXITEM HEXITEM HEXITEM HEXITEM HEXITEM HEXITEM;

APOSTROPHE: '\'';

ID: [a-zA-Z_] [a-zA-Z_0-9]*;
INT: '-'? [0-9]+;
FLOAT: '-'? [0-9]+? '.' [0-9]*;
STRING: ('"' | APOSTROPHE) ((~["\r\n] | ~['\r\n]) | ('""' | '\'\''))* ('"' | APOSTROPHE);

/* Jade Parser */
parse: stmt* EOF;

block: LBRACE stmt* RBRACE | stmt;

stmt
    : call
    | varAssign
    | funcAssign
    | expr
    | classdef
    | ifStmt
    | whileStmt
    | repeatStmt
    | importStmt
    | switchStmt
    | undefineStmt
    | tryStmt
    | BREAK
    | CONTINUE
    | RETURN expr
    ;

caseList
    : CASE atom block
    ;

switchStmt
    : SWITCH caseList* (DEFAULT atom block)?
    ;

importStmt
    : IMPORT STRING (COMMA STRING)* FROM STRING
    ;

repeatStmt
    : REPEAT block UNTIL condition
    ;

ifStmt
    : IF condition block (ELSE IF condition block)* (ELSE block)?
    ;

whileStmt
    : WHILE condition block
    ;

condition
    : LPAREN expr RPAREN
    | expr
    ;

tryStmt
    : TRY block CATCH ID block (CATCH ID block)*
    ;

undefineStmt: UNDEFINE LPAREN ID RPAREN;

inheritList: ID (COMMA ID)*;

classdef: CLASS ID RARROW inheritList?;

args: expr (COMMA expr)*;
params: ALL_KWS? ID (COMMA ALL_KWS? ID)*;

call: ID LPAREN args? RPAREN;

varAssign: (PUBLIC | PRIVATE)? CONST? ALL_KWS? ID ASSIGN expr;
funcAssign
    : (PUBLIC | PRIVATE)? OVERRIDE? (ALL_KWS? | FUNC) ID LPAREN params? RPAREN block
    | (PUBLIC | PRIVATE)? OVERRIDE? ALL_KWS? ID LPAREN params? RPAREN ARROWASSIGN block
    ;

getAttributes: atom (DOT ID LPAREN args? RPAREN)*;

indexing : atom LLIST INT RLIST;

funcExpr: ID LPAREN params? RPAREN ARROWASSIGN block;

expr
    : atom
    | call
    | getAttributes
    | funcExpr
    | indexing
    | expr op=OPERATOR expr
    | op=OPERATOR2 expr
    ;

list: LLIST args? RLIST;

atom: list | ID | INT | FLOAT | STRING | NUL | BOOL;
