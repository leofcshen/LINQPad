<Query Kind="Statements" />

int scoreStandard = 90;
int score95 = 95;
int score80 = 80;

string good = "你超強";
string poor = "你就爛";

//一般方法
string GetComment(int pScore) {
  string comment;

  if (pScore > scoreStandard) {
    comment = good;
  } else {
    comment = poor;
  }

  return comment;
}

GetComment(score95).Dump(nameof(GetComment) + " " + score95);
GetComment(score80).Dump(nameof(GetComment) + " " + score80);

//三元Lambda
string GetComment_三元_Lambda(int pScore) => pScore > scoreStandard ? good : poor;

GetComment_三元_Lambda(score95).Dump(nameof(GetComment_三元_Lambda) + " " + score95);
GetComment_三元_Lambda(score80).Dump(nameof(GetComment_三元_Lambda) + " " + score80);

//三元原型
string GetComment_三元_原型(int pScore) {
  string comment;
  comment = pScore > scoreStandard ? good : poor;
  return comment;
}

GetComment_三元_原型(score95).Dump(nameof(GetComment_三元_原型) + " " + score95);
GetComment_三元_原型(score80).Dump(nameof(GetComment_三元_原型) + " " + score80);

//三元簡化
string GetComment_三元_簡化(int pScore) {
  return pScore > scoreStandard ? good : poor;
}

GetComment_三元_簡化(score95).Dump(nameof(GetComment_三元_簡化) + " " + score95);
GetComment_三元_簡化(score80).Dump(nameof(GetComment_三元_簡化) + " " + score80);

//匿名方法要先宣告
var getComment = (int pScore) => pScore > scoreStandard ? good : poor;

getComment(score95).Dump(nameof(getComment) + " " + score95);
getComment(score80).Dump(nameof(getComment) + " " + score80);