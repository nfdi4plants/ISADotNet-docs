---
layout: docs
title: Querymodel
published: 2023-02-14
Author: Heinrich Lukas Weil <https://github.com/HLWeil>
add toc: true
add sidebar: _sidebars\mainSidebar.md
Article Status: Publishable
To-Dos: 
    - Update links to other KB articles
---

# Querymodel

The querymodel is used to intuitively retreive information from the ISA metadata. 

```fsharp

#r @"nuget: ISADotNet.XLSX"

open ISADotNet


let _,_,persons,a = ISADotNet.XLSX.AssayFile.Assay.fromFile assayPath

let qa = QueryModel.QAssay.fromAssay a

```

### Retreiving values:

```fsharp
let firstValue = qa.Values().First

firstValue.NameText
firstValue.ValueText
```
-> 
```
val it: string = "Sample type"

val it: string = "cell culture"
```

### Retreiving nodes:

```fsharp
qa.Sources.Head
qa.FirstSamples.Head
qa.FirstData.Head
qa.LastData.Head
```
-> 
```

val it: string = "001_uncult_8°"

val it: string = "001-007_uncult_8°_son"

val it: string = "20210913_1558_001.mzml"

val it: string = "20210913_1558_001.mzml"
```

### Nodes as anchors:

```fsharp
let nodeOfInterest = qa.Samples.[5]

nodeOfInterest.FirstProcessedData
// or 
qa.FirstProcessedDataOf(nodeOfInterest)
```
->
```
val nodeOfInterest: string = "008-014_uncult_22°_ext"

val it: string list =
  ["20210913_1558_021.mzml"; "20210913_1558_022.mzml";
   "20210913_1558_023.mzml"; "20210913_1558_024.mzml";
   "20210913_1558_025.mzml"; "20210913_1558_026.mzml";
   "20210913_1558_027.mzml"; "20210913_1558_028.mzml";
   "20210913_1558_029.mzml"; "20210913_1558_030.mzml";
   "20210913_1558_031.mzml"; "20210913_1558_032.mzml";
   "20210913_1558_033.mzml"; "20210913_1558_034.mzml";
   "20210913_1558_035.mzml"; "20210913_1558_036.mzml";
   "20210913_1558_037.mzml"; "20210913_1558_038.mzml";
   "20210913_1558_039.mzml"; "20210913_1558_040.mzml"]
```
----
```fsharp
nodeOfInterest.Sources
```
->
```
val it: string list =
  ["008_uncult_22°"; "009_uncult_22°"; "010_uncult_22°"; "011_uncult_22°";
   "012_uncult_22°"; "013_uncult_22°"; "014_uncult_22°"]
```
----
```fsharp
nodeOfInterest.PreviousCharacerstics
    .Item("Organism")
    .ValueText
```
->
```
val it: string = "Chlamydomonas rheinhardtii"
```
----
```fsharp
nodeOfInterest.SucceedingParameters
|> Seq.map (fun p -> p.HeaderText,p.ValueText)
|> Seq.take 5
|> Seq.toList
```
->
```
val it: (string * string) list =
  [("Parameter [Library strategy]", "Illumina library prep");
   ("Parameter [Library Selection]", "cDNA");
   ("Parameter [Library layout]", "single-end");
   ("Parameter [Library preparation kit]",
    "CleanTag® Small RNA Library Prep Kit");
   ("Parameter [Library preparation kit version]", "3")]
```
