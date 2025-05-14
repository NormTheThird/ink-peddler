import os
import sys
import argparse
import fileinput

argparser = argparse.ArgumentParser(add_help=False)
argparser.add_argument('version', help='The version number of the APK or IPA')

flags = argparser.parse_args()
version = flags.version

with open('config.xml', 'r') as file :
  filedata = file.read()

filedata = filedata.replace('{app-version}', version)
filedata = filedata.replace('{app-version-name}', '0.0.' + version)

with open('config.xml', 'w') as file:
  file.write(filedata)