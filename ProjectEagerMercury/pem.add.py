#!/usr/bin/python

#Add file to a project.

import sys, getopt
import glob, os

extension = ".pro.pem"
csextension = ".cs"
project_name = "project_name = "
source = "source:"
specification = "specification:"
gen = "./pem.gen.py "

def main(argv):
	command = argv
	file = open(str(command[1]), 'r')
	lines = file.readlines()
	file.close();

	j = 0;

	os.system(gen + " ".join(command[2]))
	

	if not "\t" + command[2] + ".py\n" in lines:
		while (lines[j] != (source + '\n')):
			j += 1
		while (lines[j] != "\n"):
			j += 1
		lines.insert(j, "\t" + str(command[2]) + csextension + "\n")

		file = open(str(command[1]), 'w')
		file.writelines(lines)
		file.close()
	else:
		print "File already exists!"



	


if __name__ == "__main__":
   main(sys.argv)