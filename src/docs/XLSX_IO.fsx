#r "nuget: ISADotNet.XLSX"

open ISADotNet.XLSX

let investigationFilePath = ""
let investigation = Investigation.fromFile investigationFilePath
Investigation.toFile investigationFilePath investigation


open ISADotNet.XLSX.StudyFile

let studyFilePath = ""
let study = Study.fromFile investigationFilePath
Study.toFile studyFilePath study

open ISADotNet.XLSX.AssayFile

let assayFilePath = ""
let contacts,assay = Assay.fromFile investigationFilePath
Assay.toFile assayFilePath contacts assay