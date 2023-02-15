---
layout: docs
title: XLSX
published: 2023-02-14
Author: Heinrich Lukas Weil <https://github.com/HLWeil>
add toc: true
add sidebar: _sidebars\mainSidebar.md
Article Status: Publishable
To-Dos: 
    - Update links to other KB articles
---

# ISA-XLSX

https://isa-specs.readthedocs.io/en/latest/isatab.html

ISADotNet contains a `fromString` and `toString` function for the three ISA-XLSX files. These files follow the object defined by the official `ISA-Json` schema:

## Investigation

https://isa-specs.readthedocs.io/en/latest/isatab.html#investigation-file

```fsharp
#r "nuget: ISADotNet.XLSX"

open ISADotNet.XLSX

let investigationFilePath = ""
let investigation = Investigation.fromFile investigationFilePath
Investigation.toFile investigationFilePath investigation
```

## Assay/Study

https://isa-specs.readthedocs.io/en/latest/isatab.html#study-and-assay-files

```fsharp
open ISADotNet.XLSX.StudyFile

let studyFilePath = ""
let study = Study.fromFile investigationFilePath
Study.toFile studyFilePath study


open ISADotNet.XLSX.AssayFile

let assayFilePath = ""
let contacts,assay = Assay.fromFile investigationFilePath
Assay.toFile assayFilePath contacts assay
```
