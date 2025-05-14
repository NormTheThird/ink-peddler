import os
import sys
import argparse
import fileinput

argparser = argparse.ArgumentParser(add_help=False)
argparser.add_argument('env_type', help='The type of environment this is going to run on. "prod, dev, test, staging, etc...."')

flags = argparser.parse_args()
env_type = flags.env_type

with open('src/providers/app-config.ts', 'r') as file :
  filedata = file.read()

filedata = filedata.replace('{ci_build_environment}', env_type)

with open('src/providers/app-config.ts', 'w') as file:
  file.write(filedata)