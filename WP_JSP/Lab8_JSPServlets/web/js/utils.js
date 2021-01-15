function placeVaporForUser(i, j, UID, callbackFunction) {
    $.get("GameController",
        { action: "placeVapor",
            i: i,
            j: j,
            UID: UID
        },
        callbackFunction
    );
}

function placeSignal(i, j, k) {
    $.get("GameController",
        { action: "checkPlace",
            i: i,
            j: j,
        },
        increment(k));
}

function increment(k) {
    k = k + 1;
    return k;
}

function hitTarget(i, j, UID, callbackFunction) {
    $.get("GameController",
        { action: "hitVapor",
            i: i,
            j: j,
            UID: UID
        },
        callbackFunction
    );
}