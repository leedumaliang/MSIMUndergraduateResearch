# I'm the biggest boss that you seen thus far.

import subprocess
import sys
import os
import time
from optparse import OptionParser
import re
import pickle

bossLog=open('bossLog.txt', 'w')
bossLog.write('Starting...')
bossLog.flush()
SimP=subprocess.Popen('SSSQ.exe', stdin=subprocess.PIPE, stderr=subprocess.PIPE, stdout=subprocess.PIPE)
VizP=subprocess.Popen('TestViz.exe', stdin=subprocess.PIPE, stderr=subprocess.PIPE, stdout=subprocess.PIPE)
stuff=SimP.stdout.readline()
while stuff != '999':
    bossLog.write('%s \n' % stuff)
    bossLog.flush()
    VizP.stdin.write(stuff)
    VizP.stdin.flush()
