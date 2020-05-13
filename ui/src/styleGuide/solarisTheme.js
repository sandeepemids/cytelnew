import { createMuiTheme } from "@material-ui/core/styles";
import { colors } from "./colors";

const solarisTheme = createMuiTheme({
  palette: {
    primary: { main: colors.primaryBlue, light: colors.secondaryBlue },
    secondary: { main: colors.gray80, light: colors.gray20 },
    background: { default: colors.primarySurface },
    error: { main: colors.primaryRed, primary: colors.orange },
    text: { primary: colors.gray100 },
  },
  breakpoints: {
    keys: ["xs", "sm", "md", "lg", "xl"],
    values: {
      xs: 0,
      sm: 600,
      md: 960,
      lg: 1280,
      xl: 1920,
    },
  },
  shape: {
    borderRadius: 4,
  },
  typography: {
    colorTextPrimary: colors.textPrimary,
    useNextVariants: true,
    fontFamily: "Roboto",
    fontStyle: "normal",
    fontWeight: "normal",
    letterSpacing: "0.25px",
    body1: {
      fontSize: 16,
      lineHeight: "24px",
      letterSpacing: "0.50px",
    },
    body2: {
      fontSize: 14,
      lineHeight: "20px",
      letterSpacing: "0.25px",
    },
    subtitle1: {
      fontSize: "12px",
      lineHeight: "16px",
      letterSpacing: "0.4px",
    },
    h1: {
      fontWeight: 500,
      fontSize: "20px",
      lineHeight: "24px",
      letterSpacing: "-0.4px",
    },
    h2: {
      fontSize: "18px",
      lineHeight: "22px",
      letterSpacing: "0.15px",
    },
    h6: {
      fontSize: "20px",
      lineHeight: "24px",
      letterSpacing: "0.15px",
    },
  },
  overrides: {
    MuiDivider: {
      root: {
        margin: "20px 0px",
      },
    },
    MuiAppBar: {
      colorPrimary: {
        backgroundColor: colors.primarySurface,
        color: colors.gray80,
      },
    },
    MuiPaper: {
      elevation4: {
        boxShadow: "none",
        borderBottom: `1px solid ${colors.gray20}`,
      },
      elevation1: {
        boxShadow: "none",
        border: `1px solid ${colors.gray20}`,
      },
    },
    MuiContainer: {
      maxWidthLg: {
        maxWidth: "1140px!important",
      },
    },
    MuiToolbar: {
      gutters: {
        padding: "0!important",
      },
    },
    MuiOutlinedInput: {
      input: {
        padding: 14,
        fontSize: 14,
        lineHeight: "20px",
        letterSpacing: "0.25px",
      },
    },
    MuiInputLabel: {
      outlined: {
        transform: "translate(10px, 15px) scale(.9)",
      },
      asterisk: {
        color: colors.primaryRed,
      },
    },
    MuiFab: {
      root: {
        color: colors.primarySurface,
        backgroundColor: colors.primaryBlue,
        "&:hover": {
          backgroundColor: colors.primaryBlue,
        },
      },
    },
    MuiCardContent: {
      root: {
        padding: 32,
      },
    },
    MuiTableCell: {
      root: {
        padding: 12,
      },
      head: {
        color: colors.gray80,
        letterSpacing: "0.4px",
      },
    },
    MuiButton: {
      root: {
        fontSize: 14,
        lineHeight: "16px",
        letterSpacing: "1.25px",
        fontWeight: 500,
        padding: "8px 16px!important",
      },
    },
    MuiMenuItem: {
      root: {
        fontSize: 14,
        lineHeight: "20px",
        letterSpacing: "0.25px",
        padding: "10px!important",
        fontWeight: "normal",
      },
    },
    MuiListItemIcon: {
      root: {
        minWidth: "35px",
        textAlign: "center",
        display: "inline-block",
        fill: colors.gray80,
      },
    },
    MuiCardHeader: {
      title: {
        fontSize: "16px",
        lineHeight: "24px",
        letterSpacing: "0.15px",
      },
    },
    MuiAutocomplete: {
      input: {
        padding: "5px!important",
      },
    },
    MuiSelect: {
      select: {
        "&:focus": {
          backgroundColor: colors.primarySurface,
        },
      },
    },
    MuiCardHeader: {
      title: {
        fontSize: "16px",
        lineHeight: "24px",
        letterSpacing: "0.15px",
      },
    },
    MuiTab: {
      root: {
        minWidth: "89px!important",
        textTransform: "nome",
      },
    },
  },
});

export default solarisTheme;
