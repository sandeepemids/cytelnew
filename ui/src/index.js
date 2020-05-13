import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import { Provider } from "react-redux";
import { store } from "./store/store";
import * as serviceWorker from "./serviceWorker";
import solarisTheme from "./styleGuide/solarisTheme";
import { MuiThemeProvider } from "@material-ui/core";
import { BrowserRouter as Router } from "react-router-dom";
import Routes from "./Routes";
import I18nProvider from "./components/i18nProvider/I18nProvider";
import { getLocaleCode } from "./locales/locales";

const configureStore = store();

const browserLanguage = (navigator.languages && navigator.languages[0])
               || navigator.language
               || navigator.userLanguage
               || 'en-US';

const languageCode = browserLanguage.split(/[-_]/)[0];

ReactDOM.render(
  <Provider store={configureStore}>
    <MuiThemeProvider theme={solarisTheme}>
      <I18nProvider locale={getLocaleCode(languageCode)}>
        <Router>
          <Routes />
        </Router>
      </I18nProvider>
    </MuiThemeProvider>
  </Provider>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
