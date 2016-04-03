#!/usr/bin/python

#Delete all dependes from .pro file.

import sys, getopt
import glob, os

extension = ".pro.pem"
csextension = ".cs"
project_name = "project_name = "
source = "source:"
specification = "specification:"

def main(argv):
	command = argv
	pro_file = open(str(command[1]), 'r')
	lines = pro_file.readlines()
	j = 0
	while (lines[j] != (source + '\n')):
		j += 1
	j += 1
	while (lines[j] != "\n"):
		filename = "".join(lines[j].split(".").pop())
		print filename
		print "./src/" + "/".join(filename.split(".")) + "/" + filename + csextension
		os.system("./src/" + "/".join(filename.split(".")) + "/" + filename + csextension)
		j += 1

	pro_file.close()





	


if __name__ == "__main__":
   main(sys.argv)