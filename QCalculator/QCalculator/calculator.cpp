#include "calculator.h"
#include "ui_calculator.h"
#include "SortStation/reader.h"

Calculator::Calculator(QWidget *parent) :
  QDialog(parent),
  ui(new Ui::Calculator)
{
  ui->setupUi(this);

  QObject::connect(ui->one, SIGNAL(clicked()), this, SLOT(enterOne()));
  connect(ui->two, SIGNAL(clicked()), this, SLOT(enterTwo()));
  connect(ui->three, SIGNAL(clicked()), this, SLOT(enterThree()));
  connect(ui->four, SIGNAL(clicked()), this, SLOT(enterFour()));
  connect(ui->five, SIGNAL(clicked()), this, SLOT(enterFive()));
  connect(ui->six, SIGNAL(clicked()), this, SLOT(enterSix()));
  connect(ui->seven, SIGNAL(clicked()), this, SLOT(enterSeven()));
  connect(ui->eight, SIGNAL(clicked()), this, SLOT(enterEight()));
  connect(ui->nine, SIGNAL(clicked()), this, SLOT(enterNine()));
  connect(ui->zero, SIGNAL(clicked()), this, SLOT(enterZero()));
  connect(ui->add, SIGNAL(clicked()), this, SLOT(enterPlus()));
  connect(ui->subtract, SIGNAL(clicked()), this, SLOT(enterSubtract()));
  connect(ui->multiply, SIGNAL(clicked()), this, SLOT(enterMultiply()));
  connect(ui->divide, SIGNAL(clicked()), this, SLOT(enterDivide()));

}

Calculator::~Calculator()
{
  delete ui;
}

void Calculator::enterOne()
{
  ui->inputLine->insert("1");
}
void Calculator::enterTwo()
{
  ui->inputLine->insert("2");
}
void Calculator::enterThree()
{
  ui->inputLine->insert("3");
}
void Calculator::enterFour()
{
  ui->inputLine->insert("4");
}
void Calculator::enterFive()
{
  ui->inputLine->insert("5");
}
void Calculator::enterSix()
{
  ui->inputLine->insert("6");
}
void Calculator::enterSeven()
{
  ui->inputLine->insert("7");
}
void Calculator::enterEight()
{
  ui->inputLine->insert("8");
}
void Calculator::enterNine()
{
  ui->inputLine->insert("9");
}
void Calculator::enterZero()
{
  ui->inputLine->insert("0");
}
void Calculator::enterPlus()
{
  ui->inputLine->insert("+");
}
void Calculator::enterSubtract()
{
  ui->inputLine->insert("-");
}
void Calculator::enterMultiply()
{
  ui->inputLine->insert("*");
}
void Calculator::enterDivide()
{
  ui->inputLine->insert("/");
}

