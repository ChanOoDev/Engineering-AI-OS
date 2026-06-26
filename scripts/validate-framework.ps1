# Validates the Engineering AI OS markdown contracts.

$ErrorActionPreference = "Stop"

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot "..")
$errors = New-Object System.Collections.Generic.List[string]

function Test-RequiredSections {
    param(
        [string]$Path,
        [string[]]$Sections
    )

    $content = Get-Content -Raw -LiteralPath $Path
    foreach ($section in $Sections) {
        $pattern = "(?m)^##\s+$([regex]::Escape($section))\s*$"
        if ($content -notmatch $pattern) {
            $relative = Resolve-Path -LiteralPath $Path -Relative
            $errors.Add("$relative is missing section: $section")
        }
    }
}

function Test-NonPlaceholder {
    param(
        [string]$Path,
        [int]$MinimumLength
    )

    $item = Get-Item -LiteralPath $Path
    if ($item.Length -lt $MinimumLength) {
        $relative = Resolve-Path -LiteralPath $Path -Relative
        $errors.Add("$relative looks too small to be actionable ($($item.Length) bytes)")
    }
}

$commandSections = @("Required Input", "Read First", "Execution Steps", "Output Format")
Get-ChildItem -LiteralPath (Join-Path $repoRoot ".ai/commands") -Filter "*.md" | ForEach-Object {
    Test-RequiredSections -Path $_.FullName -Sections $commandSections
}

$workflowSections = @("Inputs", "Agents", "Flow", "Failure Branches", "Done Criteria")
Get-ChildItem -LiteralPath (Join-Path $repoRoot ".ai/workflows") -Filter "*.md" | ForEach-Object {
    Test-RequiredSections -Path $_.FullName -Sections $workflowSections
}

$specSections = @("Objective", "Acceptance Criteria", "Test Cases", "Security", "Rollback Plan")
Get-ChildItem -LiteralPath (Join-Path $repoRoot "docs/specs/features") -Filter "*.md" | ForEach-Object {
    Test-RequiredSections -Path $_.FullName -Sections $specSections
    Test-NonPlaceholder -Path $_.FullName -MinimumLength 1000
}

$moduleSpecSections = @("Purpose", "Responsibilities", "Dependencies", "APIs", "Data Model", "Security", "Logging", "Tests", "Known Limitations")
Get-ChildItem -LiteralPath (Join-Path $repoRoot "docs/specs/modules") -Filter "*.md" | ForEach-Object {
    Test-RequiredSections -Path $_.FullName -Sections $moduleSpecSections
    Test-NonPlaceholder -Path $_.FullName -MinimumLength 1200
}

$promptSections = @("Focus", "Output")
Get-ChildItem -LiteralPath (Join-Path $repoRoot ".ai/prompts") -Recurse -Filter "*.md" | ForEach-Object {
    Test-RequiredSections -Path $_.FullName -Sections $promptSections
    Test-NonPlaceholder -Path $_.FullName -MinimumLength 700
}

$standardMinimums = @{
    "api.md" = 1000
    "coding.md" = 1000
    "error-handling.md" = 1000
    "logging.md" = 900
    "performance.md" = 1000
    "security.md" = 1000
    "testing.md" = 1000
}

foreach ($entry in $standardMinimums.GetEnumerator()) {
    $path = Join-Path $repoRoot "docs/standards/$($entry.Key)"
    if (Test-Path -LiteralPath $path) {
        Test-NonPlaceholder -Path $path -MinimumLength $entry.Value
    } else {
        $errors.Add("docs/standards/$($entry.Key) is missing")
    }
}

if ($errors.Count -gt 0) {
    Write-Host "Framework validation failed:" -ForegroundColor Red
    foreach ($errorMessage in $errors) {
        Write-Host "- $errorMessage"
    }
    exit 1
}

Write-Host "Framework validation passed."
