#ifndef CALCULATOR_H
#define CALCULATOR_H

#include <QDialog>
#include <QSignalMapper>

namespace Ui {
  class Calculator;
}

class Calculator : public QDialog
{
  Q_OBJECT

public:
  explicit Calculator(QWidget *parent = 0);
  ~Calculator();

private:
  Ui::Calculator *ui;

  QSignalMapper *signalMapper;

private slots:
  void enterOne();
  void enterTwo();
  void enterThree();
  void enterFour();
  void enterFive();
  void enterSix();
  void enterSeven();
  void enterEight();
  void enterNine();
  void enterZero();
  void enterPlus();
  void enterSubtract();
  void enterMultiply();
  void enterDivide();

};

#endif // CALCULATOR_H
