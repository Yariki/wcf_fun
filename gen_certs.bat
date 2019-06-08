makecert.exe -r -n "CN=WCFRoot" -pe -ss Root -sr LocalMachine -sky signature -m 120 -a sha256 -len 2048

makecert -pe -n "CN=WCFServer" -a sha256 -len 2048 -sky exchange -eku 1.3.6.1.5.5.7.3.1 -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 -in "WCFRoot" -is Root -ir LocalMachine -ss My -sr LocalMachine -m 13 funSoftServerCert.cer

makecert -pe -n "CN=WCFClient" -a sha256 -len 2048 -sky exchange -eku 1.3.6.1.5.5.7.3.2 -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12 -in "WCFRoot" -is Root -ir LocalMachine -ss My -sr LocalMachine -m 13 funSoftClientCert.cer 