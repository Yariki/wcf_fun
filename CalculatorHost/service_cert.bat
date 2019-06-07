makecert.exe  -sr CurrentUser -ss My -a sha1 -n CN=CalculatorService -sky exchange -pe
certmgr.exe -add -r CurrentUser -s My -c -n CalculatorService -r CurrentUser -s TrustedPeople