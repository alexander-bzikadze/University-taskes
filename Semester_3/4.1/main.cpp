#include <iostream>

#include <QApplication>

#include "graphicEditor.hpp"

using namespace std;

int main(int argc, char *argv[])
{
	QApplication a(argc, argv);
	GraphicEditor w;
	w.show();

	return a.exec();
}