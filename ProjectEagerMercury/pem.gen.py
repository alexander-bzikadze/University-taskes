#!/usr/bin/python

#Generate added to a project file.

import sys, getopt
import glob, os

extension = ".pro.pem"
csextension = ".cs"
project_name = "project_name = "
source = "source:"
specification = "specification:"

def main(argv):
	command = argv
	pro_files = glob.glob("*" + extension)
	pro_file = open(pro_files[0], 'r')
	

	path = "/".join(command[1].split("."))
	if not (os.path.exists("./src/" + path)):
		os.makedirs("./src/" + path)
	file = open("./src/" + path + "/" + command[1] + csextension, 'w')
	namespace = pro_file.readline().split()[2]

	file.write("using System;\nusing System.Collections.Generic;\n")

	if (len(command) > 2):
		if (command[2] == "wnf"):
			file.write("using System.Drawing;\nusing System.Windows.Forms;\n")

	file.write("\n\n")

	file.write("namespace " + namespace + "\n{\n\tpublic class " + "".join(command[1].split(".")) + "\n\t{\n\t\t\n\t}\n}")

	file.close()
	pro_file.close()
	


if __name__ == "__main__":
   main(sys.argv)