cpu=`mpstat | awk 'FNR==4 { print $3 }'`
ram=`cat /proc/meminfo | awk 'FNR==2 { print $2/1024 }'|tr . ,`
dysk=`iostat -x | awk 'FNR==7 { print $9 }'`
serwer=`hostname`
dtapr=`date '+%Y-%m-%d'`
godzpr=`date '+%H:%M:%S'`
dta=$dtapr%20$godzpr

curl -X GET 'http://srvmgrap01/signalr/Pomiary/MonitorZapiszPomiar?serwer='$serwer'&cpu='$cpu'&ram='$ram'&dysk='$dysk'&data='$dta

