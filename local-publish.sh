powershell Remove-Item './.publish' -Recurse

powershell Remove-Item './src/Amazon.DateTime/bin' -Recurse
dotnet clean ./src/Amazon.DateTime/Amazon.DateTime.csproj
dotnet publish ./src/Amazon.DateTime/Amazon.DateTime.csproj -o ./.publish/Amazon.DateTime
powershell Compress-Archive -Path './.publish/Amazon.DateTime/*' -DestinationPath './.publish/Amazon.DateTime.zip'
powershell Remove-Item './.publish/Amazon.DateTime' -Recurse
powershell Move-Item -Path ./src/Amazon.DateTime/bin/Debug/*.nupkg -Destination ./.publish