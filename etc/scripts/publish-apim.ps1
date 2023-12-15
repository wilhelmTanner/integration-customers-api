# Script Powershell para crear un Producto y una API en Azure API Managment
# Requerido: Powershell y modulo Az para powershell
# author: varios

#parameters
$environment = $args[0]

# dev
$subscriptionId = "293c1183-8b08-4bbd-9f28-e042fd037525" # EATannerDev
$rgApim = "RG_ApimTanner_Des" # Resource group name
$svcNameApim = "apimtanner-dev" # APIM service name
$svcUrl = "https://nginx-dev.tanner.cl/enterprise/payment-button/main" # Backend services url
$urlSwagger = "https://nginx-dev.tanner.cl/enterprise/payment-button/main/swagger/1.0/swagger.json" # Swagger specification
$apimSubscriptionId = "payment-button-api" # identificador de la subscripcion al Producto en el APIM

if ($environment -ne "dev" -and $environment -ne "qa" -and $environment -ne "uat" -and $environment -ne "prod")
{
  Write-Host "The possibles values are: dev, qa, uat, prod"
  return
}

if ($environment -eq "qa")
{
    $subscriptionId = "c24bad97-a494-43fe-96fc-e1b441316c92" # EATannerQA
    $rgApim = "RG_ApimTanner_QA"
    $svcNameApim = "apimtanner-qa"
    $svcUrl = "https://nginx-qa2.tanner.cl/enterprise/payment-button/main" # Backend services url
    $urlSwagger = "https://nginx-qa2.tanner.cl/enterprise/payment-button/main/swagger/1.0/swagger.json" # Swagger specification
}

if ($environment -eq "uat")
{
    $subscriptionId = "c24bad97-a494-43fe-96fc-e1b441316c92" # EATannerUAT
    $rgApim = "rg-api-management-uat"
    $svcNameApim = "api-tanner-uat"
    $svcUrl = "https://nginx-uat.tanner.cl/enterprise/payment-button/main" # Backend services url
    $urlSwagger = "https://nginx-uat.tanner.cl/enterprise/payment-button/main/swagger/1.0/swagger.json" # Swagger specification
}

if ($environment -eq "prod")
{
    $subscriptionId = "858875e0-ac97-41a4-b389-887600375d5c"
    $rgApim = "RG-API-Management"
    $svcNameApim = "api-tanner"
    $svcUrl = "https://nginx-prod.tanner.cl/enterprise/payment-button/main" # Backend services url
    $urlSwagger = "https://nginx-prod.tanner.cl/enterprise/payment-button/main/swagger/v1/swagger.json" # Swagger specification
}

$productId = "payment-button"
$versionSetId = "payment-button"
$apiVersion = "1.0"
$apiId = "payment-button-api"
$apiUrlSuffix = "enterprise/payment-button/main" # Path

Connect-AzAccount

Select-AzSubscription -SubscriptionId $subscriptionId

Write-Host "Obteniendo contexto del API Managment..."
# Get Context APIM
$apimContext = New-AzApiManagementContext -ResourceGroupName $rgApim -ServiceName $svcNameApim

Write-Host "Obteniendo producto $productId..."
# Get Product
$apimProduct = Get-AzApiManagementProduct -ProductId $productId -Context $apimContext

if ($null -eq $apimProduct)
{
    Write-Host "Producto $productId no encontrado"
    Write-Host "Creando producto $productId..."
    # Create Product
    New-AzApiManagementProduct -Context $apimContext `
                -ProductId $productId `
                -Title "payment-button-api" `
                -Description "Producto asociado al api transversal de botón de pagos" `
                -SubscriptionRequired $True `
                -State "Published" `
                -ApprovalRequired $True
}

Write-Host "Importando API desde $urlSwagger"
# Import an API from url swagger specification
Import-AzApiManagementApi -Context $apimContext `
        -ApiId $apiId `
        -SpecificationUrl $urlSwagger `
        -SpecificationFormat OpenApi `
        -Path $apiUrlSuffix `
        -ServiceUrl $svcUrl `
        -Protocol @("https") 

# Obtener subscription 
$subsApim = Get-AzApiManagementSubscription -Context $apimContext | Where-Object { $_.SubscriptionId -eq "$apimSubscriptionId" }
if ($null -eq $subsApim) 
{
  New-AzApiManagementSubscription `
       -Context $apimContext `
       -SubscriptionId $apimSubscriptionId `
       -Name "API Botón de pago" `
       -Scope "/apis/$apiId" `
       -UserId 1 `
       -AllowTracing
}

# Add subscription required to API
#Set-AzApiManagementApi -Context $apimContext `
#        -ApiId $apiId `
#        -SubscriptionRequired `
#        -SubscriptionKeyHeaderName "Ocp-Apim-Subscription-Key" `
#        -SubscriptionKeyQueryParamName "subscription-key"

# Add Api to Product
Add-AzApiManagementApiToProduct -Context $apimContext -ProductId $productId -ApiId $apiId

# Add product to groups
Add-AzApiManagementProductToGroup -Context $apimContext -ProductId $productId -GroupId "guests"
Add-AzApiManagementProductToGroup -Context $apimContext -ProductId $productId -GroupId "developers"