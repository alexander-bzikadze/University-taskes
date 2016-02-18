#include <QApplication>
#include "mydialogwindow.h"

int main(int argc, char *argv[])
{
  QApplication a(argc, argv);
  MyDialogWindow *b = new MyDialogWindow();

  b->show();


  return a.exec();
}
