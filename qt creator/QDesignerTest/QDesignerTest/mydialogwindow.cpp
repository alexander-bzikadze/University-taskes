#include "mydialogwindow.h"
#include "ui_mydialogwindow.h"

MyDialogWindow::MyDialogWindow(QWidget *parent) :
  QDialog(parent),
  ui(new Ui::MyDialogWindow)
{
  ui->setupUi(this);
  ui->OKButton->setEnabled(false);

  QRegExp exp("[a-zA-Z]{1,5}[1-9]{1}[0-9]{0,3}");
  ui->lineEdit->setValidator(new QRegExpValidator(exp, this));
  connect(ui->lineEdit, SIGNAL(textChanged(QString)), this, SLOT(OkEnabled()));
}

MyDialogWindow::~MyDialogWindow()
{
  delete ui;
}

void MyDialogWindow::OkEnabled()
{
  ui->OKButton->setEnabled(ui->lineEdit->hasAcceptableInput());
}

void MyDialogWindow::on_pushButton_clicked()
{
  static bool open = true;

  ui->First_2->setVisible(open);

  open = !open;
}
