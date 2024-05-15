param (
    [Parameter(Mandatory=$true, ParameterSetName='ByName')]
    [string]$Name,
        
    [Parameter(Mandatory=$true, ParameterSetName='ByID')]
    [int]$ID
)
 
Write-Output "Fetching user information by Name: $Name $ID"