$dnsAddresses = "172.30.0.1"
$ifIndex = (Get-NetAdapter)[0].InterfaceIndex
cmd /c "netsh.exe interface ipv4 set subinterface $($ifIndex) mtu=1400 store=persistent"
Set-DnsClientServerAddress -InterfaceIndex $ifIndex -ServerAddresses $dnsAddresses
c:\servicemonitor.exe w3svc