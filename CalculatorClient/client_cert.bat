makecert.exe  -sr CurrentUser -ss My -a sha1 -n CN=WCFUser -sky exchange -pe
certmgr.exe -add -r CurrentUser -s My -c -n WCFUser -r CurrentUser -s TrustedPeople