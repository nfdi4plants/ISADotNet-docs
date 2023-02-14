#r "nuget: ISADotNet"

open ISADotNet.Json

let ontologyString =
    """{"annotationValue":"plant growth protocol","termSource":"DPBO","termAccession":"http://purl.obolibrary.org/obo/DPBO_1000164"}"""

let oa = OntologyAnnotation.fromString ontologyString

OntologyAnnotation.toString oa


let investigationFilePath = ""
let investigation = Investigation.fromFile investigationFilePath
Investigation.toFile investigationFilePath investigation

let assayFilePath = ""
let assay = Assay.fromFile investigationFilePath
Assay.toFile assayFilePath assay




open ISADotNet

let listOfContactsPath = ""
let contacts = JsonExtensions.fromFile<Person list> listOfContactsPath
JsonExtensions.toFile listOfContactsPath contacts



#r "nuget: ISADotNet.Validation"

open ISADotNet.Validation

let correctOntologyString =
    """{"annotationValue":"plant growth protocol","termSource":"DPBO","termAccession":"http://purl.obolibrary.org/obo/DPBO_1000164"}"""

JSchema.validateOntologyAnnotation correctOntologyString


let wrongOntologyString =
    """{"annotationValue":"plant growth protocol","termSource":123,"termAccession":""}"""

JSchema.validateOntologyAnnotation wrongOntologyString
