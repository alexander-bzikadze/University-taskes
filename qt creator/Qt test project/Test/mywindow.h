#ifndef MYWINDOW_H
#define MYWINDOW_H

#include <QDialog>
#include <QLabel>
#include <QLineEdit>
#include <QCheckBox>
#include <QPushButton>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QMessageBox>

class MyWindow : public QDialog
{
  Q_OBJECT

public:
  MyWindow(QWidget *parent = 0);

private:
  QLabel *lbl;
  QLineEdit *line;
  QCheckBox *cb1;
  QCheckBox *cb2;
  QPushButton *ok;
  QPushButton *close;

private slots:
  void OkClicked();
  void TextChanged(QString str);

signals:
  void Register(QString str);
  void Invers(QString str);
  void Simple(QString str);
};

class str : public QObject
{
  Q_OBJECT
private:
  QString simple(QString str)
  {

  }

public slots:
  void Output(QString str, short command)
  {
    QMessageBox message;
    QString result;
    message.setText(result);
    msg.exec();
  }

  void Simple(QString str)
  {
    QMessageBox msg;
    msg.setText(str);
    msg.exec();
  }

  void Inversia(QString str)
  {
    QString result;
    for (int i = str.size() - 1; i >= 0; i--)
      {
        result += str[i];
      }

    QMessageBox msg;
    msg.setText(result);
    msg.exec();

  }

  void UpTheAlph(QString str)
  {

  }
};

#endif // MYWINDOW_H
