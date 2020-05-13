import { put } from "redux-saga/effects";

export function* SetSignedInUser(data) {
    yield put({
      type: "USER_SIGNEDIN_UPDATE",
      signedInUser: data.payload
    });
}