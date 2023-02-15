---
layout: docs
title: Linq
published: 2023-02-14
Author: Heinrich Lukas Weil <https://github.com/HLWeil>
add toc: true
add sidebar: _sidebars\mainSidebar.md
Article Status: Publishable
To-Dos: 
    - Update links to other KB articles
---

# Linq

```fsharp
#r "nuget: ISADotNet.QueryModel"

open ISADotNet.QueryModel

let sample = ps.LastSamples.Head
```

## General
```fsharp
open ISADotNet.QueryModel.Linq.Query

isa {
    for value in sample.Values do
        whereName "Cell line"
        selectValueText
        head
}           
```

## Spreadsheet

```fsharp
open ISADotNet.QueryModel.Linq.Spreadsheet
cells {
    for value in sample.Values do
        whereName "Cell line"
        selectValueText
        head
}           
```