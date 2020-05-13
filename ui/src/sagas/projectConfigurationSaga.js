import { call, put } from "redux-saga/effects";

import {
  getIndications,
  getTimeunits,
  getCurrencies,
  getPrograms,
} from "../actions/projectConfigurationAction";

export function* getProjectConfiguration(payload) {
  const indications = yield call(getIndications);
  yield put({ type: "INDICATIONS_UPDATE", indications: indications });

  const timeunits = yield call(getTimeunits);
  yield put({ type: "TIMEUNITS_UPDATE", timeunits: timeunits });

  const currencies = yield call(getCurrencies);
  yield put({ type: "CURRENCIES_UPDATE", currencies: currencies });

  const programs = yield call(getPrograms, payload.resourceID);
  yield put({ type: "PROGRAMS_UPDATE", programs: programs });
}
