---
layout: docs
title: Json
published: 2023-02-14
Author: Heinrich Lukas Weil <https://github.com/HLWeil>
add toc: true
add sidebar: _sidebars\mainSidebar.md
Article Status: Publishable
To-Dos: 
    - Update links to other KB articles
---

# ISA-Json

https://isa-specs.readthedocs.io/en/latest/isajson.html

## Serialization and Deserialization

ISADotNet contains a `fromString` and `toString` function for each json object defined by the official `ISA-Json` schema, linked above:

```fsharp
#r "nuget: ISADotNet"

let ontologyString =
    """{"annotationValue":"plant growth protocol","termSource":"DPBO","termAccession":"http://purl.obolibrary.org/obo/DPBO_1000164"}"""

let oa = OntologyAnnotation.fromString ontologyString

// val oa: ISADotNet.OntologyAnnotation =
//   { ID = None
//     Name = Some (Text "plant growth protocol")
//     TermSourceREF = Some "DPBO"
//     TermAccessionNumber = Some "http://purl.obolibrary.org/obo/DPBO_1000164"
//     Comments = None }

OntologyAnnotation.toString oa

// val it: string =
//   "{"annotationValue":"plant growth protocol","termSource":"DPBO","termAccession":"http://purl.obolibrary.org/obo/DPBO_1000164"}"

```


Or you can use the `fromFile` and `toFile` functions:

```fsharp
open ISADotNet.Json

let investigationFilePath = ""
let investigation = Investigation.fromFile investigationFilePath
Investigation.toFile investigationFilePath investigation

let assayFilePath = ""
let assay = Assay.fromFile investigationFilePath
Assay.toFile assayFilePath assay
```

## Validation

Using ISADotNet, you can also validate json strings against the json schemas. E.g. using the example from above:

```fsharp
#r "nuget: ISADotNet.Validation"

open ISADotNet.Validation

let correctOntologyString =
    """{"annotationValue":"plant growth protocol","termSource":"DPBO","termAccession":"http://purl.obolibrary.org/obo/DPBO_1000164"}"""

// val it: ValidationResult = Ok

```
If the json string does not follow the schema, the validator tell you exactly what it wrong with it:
```fsharp
let wrongOntologyString =
    """{"annotationValue":"plant growth protocol","termSource":123,"termAccession":""}"""

JSchema.validateOntologyAnnotation wrongOntologyString

// val it: ValidationResult = Failed [|"StringExpected: #/termSource"; "UriExpected: #/termAccession"|]
```

## Generic Serialization and Deserialization

You can also use the JsonSerializer from ISADotNet to serialize and deserialize variations of the standard ISA objects:

```fsharp
open ISADotNet

let listOfContactsPath = ""
let contacts = JsonExtensions.fromFile<Person list> listOfContactsPath

JsonExtensions.toFile listOfContactsPath contacts
```