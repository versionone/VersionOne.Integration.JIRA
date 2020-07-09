param(
    [alias("t")]
    [string]$tasks = ''
)

function DownloadSetup {
    $source = "https://raw.github.com/openAgile/psake-tools/fixing_ci/setup.ps1"  
    Invoke-WebRequest -Uri $source -OutFile setup.ps1
}

try {
    Write-Host "Attempting to run DownloadSetup"
    DownloadSetup
    Write-Host "Attempting to run setup.ps1 on " + $tasks
    .\setup.ps1 $tasks
}
Catch {
    Write-Host "Exception.  Blew up on trying Downloadsetup or setup"
    Write-Host $_.Exception.Message
    exit 1
}