
function updateKeywordsForDocument(documentName, documentKeyword1, documentKeyword2, documentKeyword3, documentKeyword4, documentKeyword5, callbackFunc) {
    $.getJSON(
        "AssetController",
        { action: 'updateKeywordsForDoc', documentName: documentName, documentKeyword1: documentKeyword1,
            documentKeyword2: documentKeyword2, documentKeyword3: documentKeyword3, documentKeyword4: documentKeyword4,
            documentKeyword5: documentKeyword5 },
        callbackFunc
    );
}

function getDocuments(callbackFunc) {
    $.getJSON(
        "AssetController",
        { action: 'getAllDocuments' },
        callbackFunc
    );
}

function getWebsites(callbackFunc) {
    $.getJSON(
        "AssetController",
        { action: 'getAllWebsites' },
        callbackFunc
    );
}