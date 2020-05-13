import React, { useState, useEffect } from "react";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Link from "@material-ui/core/Link";
import projectListStyle from "./projectListStyle";
import { DropDown } from "../common/dropDown";
import { useDispatch, useSelector } from "react-redux";
import moment from "moment";
import { useHistory } from "react-router-dom";
import PROJECTLIST from "./constants";
import EllipsisText from "react-ellipsis-text";
import { orderBy } from "lodash";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { CreateProject } from "../createProject";
import { FormattedMessage } from "react-intl"
import {
  faLongArrowUp,
  faLongArrowDown,
} from "@fortawesome/pro-regular-svg-icons";

function ProjectList(props) {
  let history = useHistory();
  const [isOpen, setIsOpen] = useState(false);
  const handleCreateProjectModel = () => {
    setIsOpen(!isOpen);
  };
  const classes = projectListStyle();
  const [selectedProjectId, setSelectedProjectId] = useState(0);
  const [selectedProjectStatusId, setSelectedProjectStatusId] = useState(0);
  const [defaultColumnSort, setDefaultColumnSort] = useState(PROJECTLIST.TRUE);
  const [selectedColumn, setSelectedColumn] = useState("");
  const [clickedCreatedDate, setClickedCreatedDate] = useState(
    PROJECTLIST.TRUE
  );

  const sortIconElementAsc = (
    <FontAwesomeIcon icon={faLongArrowUp} className={classes.sortIconStyle} />
  );
  const sortIconElementDesc = (
    <FontAwesomeIcon icon={faLongArrowDown} className={classes.sortIconStyle} />
  );

  const prjStatusList = useSelector(
    (state) => state.projectReducer.projectStatusList
  );
  const projectList = useSelector((state) => state.projectReducer.projects);
  const dispatch = useDispatch();
  const userName = localStorage.getItem("name");
  const resourceId = localStorage.getItem("resourceId");

  if (userName === "") {
    history.push("/login");
  }

  useEffect(() => {
    dispatch({
      type: "PROJECT_STATUS_LIST",
    });
  }, [dispatch]);

  useEffect(() => {
    dispatch({
      type: "PROJECTS_LIST",
      payload: resourceId,
    });
  }, [dispatch, resourceId]);

  const renderDropdown = () => {
    return (
      <DropDown
        label="projectStatus"
        id="projectStatus"
        data={prjStatusList}
        onMouseLeave={onMouseLeaveProjectStatus}
        handleUpdate={handleUpdateProjectStatus}
        initialLoadItemId={selectedProjectStatusId}
      ></DropDown>
    );
  };
  const onMouseLeaveProjectStatus = (event) => {
    setSelectedProjectId(null);
  };
  const handleUpdateProjectStatus = (event, projectId) => {
    event.stopPropagation();
    dispatch({
      type: "PROJECT_STATUS_UPDATE",
      action: {
        projectId: selectedProjectId,
        statusId: event.target.value,
        resourceId: resourceId,
        createdBy: userName,
      },
    });
    setSelectedProjectId(null);
  };
  const handleClick = (projectId, projectStatusId) => {
    setSelectedProjectId(projectId);
    setSelectedProjectStatusId(projectStatusId);
  };

  const handleProjectClick = (
    projectId,
    projectStatusId,
    projectName,
    createdBy,
    timeUnit
  ) => {
    let isEditMode = 0;
    if (projectStatusId === 1) {
      isEditMode = 1;
    }
    dispatch({
      type: "PROJECT_TIMEUNIT",
      action: {
        projectTimeUnit: timeUnit,
        projectId: projectId,
        createdBy: createdBy,
        isEditMode: isEditMode,
      },
    });
    history.push({
      pathname: "/landingpage/input-advisor/objective",
      state: {
        projectId: `${projectId}`,
        isEditMode,
        projectName: `${projectName}`,
        createdBy: createdBy,
        timeUnit: timeUnit,
      },
    });
  };
  const cellOnClick = (columnName) => (e) => {
    setClickedCreatedDate(PROJECTLIST.FALSE);
    setDefaultColumnSort(PROJECTLIST.TRUE);
    var SortBy = PROJECTLIST.SortOrderAsc;
    if (defaultColumnSort === PROJECTLIST.TRUE) {
      SortBy = PROJECTLIST.SortOrderDesc;
      setDefaultColumnSort(PROJECTLIST.FALSE);
    }
    setSelectedColumn(columnName);
    sortProjectList(columnName, SortBy);
    setSelectedProjectId(null);
  };
  const sortProjectList = (columnName, sortby) => {
    var SortProjectListData = [];
    SortProjectListData = JSON.parse(
      JSON.stringify(orderBy(projectList, columnName, sortby))
    );
    dispatch({ type: "PROJECTS_UPDATE", projects: SortProjectListData });
  };
  const renderSortIcon = (selectedValue, selectedColumn, columnName) => {
    if (selectedColumn === columnName) {
      return selectedValue === PROJECTLIST.FALSE
        ? sortIconElementDesc
        : sortIconElementAsc;
    } else if (columnName === PROJECTLIST.CreatedDate) {
      return clickedCreatedDate === PROJECTLIST.TRUE
        ? sortIconElementDesc
        : null;
    }
  };
  return (
    <Card id="ProjectCard">
      <CardContent className={classes.root}>
        <TableContainer component={Paper}>
          <Table size="medium" id="projectListTable">
            <TableHead>
              <TableRow>
                <TableCell
                  component="th"
                  id="projectHeaderLabel"
                  onClick={cellOnClick(PROJECTLIST.ProjectName)}
                >
                  <FormattedMessage id="projectList.project"></FormattedMessage>
                  {renderSortIcon(
                  defaultColumnSort,
                  selectedColumn,
                  PROJECTLIST.ProjectName
                )}
                </TableCell>
                <TableCell
                  id="programHeaderLabel"
                  onClick={cellOnClick(PROJECTLIST.ProgramName)}
                >
                  <FormattedMessage id="projectList.program"></FormattedMessage>
                  {renderSortIcon(
                  defaultColumnSort,
                  selectedColumn,
                  PROJECTLIST.ProgramName
                )}
                </TableCell>
                <TableCell
                  component="th"
                  id="createdHeaderLabel"
                  onClick={cellOnClick(PROJECTLIST.CreatedDate)}
                >
                  <FormattedMessage id="projectList.created"></FormattedMessage>
                  {renderSortIcon(
                  defaultColumnSort,
                  selectedColumn,
                  PROJECTLIST.CreatedDate
                )}
                </TableCell>
                <TableCell
                  component="th"
                  id="modifiedHeaderLabel"
                  onClick={cellOnClick(PROJECTLIST.LastModified)}
                >
                  <FormattedMessage id="projectList.lastModified"></FormattedMessage>
                  {renderSortIcon(
                  defaultColumnSort,
                  selectedColumn,
                  PROJECTLIST.LastModified
                )}
                </TableCell>
                <TableCell
                  component="th"
                  id="statusHeaderLabel"
                  onClick={cellOnClick(PROJECTLIST.ProjectStatus)}
                >
                  <FormattedMessage id="projectList.status"></FormattedMessage>
                  {renderSortIcon(
                  defaultColumnSort,
                  selectedColumn,
                  PROJECTLIST.ProjectStatus
                )}
                </TableCell>
                <TableCell component="th" id="actionHeaderLabel">
                  <FormattedMessage id="projectList.actions"></FormattedMessage>
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {projectList &&
                projectList.map((row) => (
                  <TableRow key={row.id}>
                    <TableCell component="td" scope="row">
                      <Link
                        onClick={() =>
                          handleProjectClick(
                            row.id,
                            row.status.id,
                            row.name,
                            row.createdBy,
                            row.projectTimeUnit.value
                          )
                        }
                        className={classes.rowCellLink}
                      >
                        <EllipsisText text={row.name} length={30} />
                      </Link>
                    </TableCell>
                    <TableCell component="td">
                      <EllipsisText text={row.program.name} length={20} />
                    </TableCell>
                    <TableCell component="td">
                      {moment(row.createdDate)
                        .format(PROJECTLIST.DATEFORMAT)
                        .toUpperCase()}
                    </TableCell>
                    <TableCell component="td">
                      {moment(row.lastModified)
                        .format(PROJECTLIST.DATEFORMAT)
                        .toUpperCase()}
                    </TableCell>
                    <TableCell
                      component="td"
                      onClick={() => handleClick(row.id, row.status.id)}
                      className={classes.handPointer}
                    >
                      {row.id !== selectedProjectId
                        ? row.status.value
                        : renderDropdown()}
                    </TableCell>
                    <TableCell component="td">
                      <Link
                        className={classes.rowCellLink}
                        onClick={() =>
                          handleProjectClick(
                            row.id,
                            row.status.id,
                            row.name,
                            row.createdBy,
                            row.projectTimeUnit.value
                          )
                        }
                      >
                        {row.status.id === 1
                          ? PROJECTLIST.EDIT
                          : PROJECTLIST.VIEW}
                      </Link>
                    </TableCell>
                  </TableRow>
                ))}
            </TableBody>
          </Table>
        </TableContainer>
      </CardContent>
      <CreateProject
        isOpen={isOpen}
        handleCreateProjectModel={handleCreateProjectModel}
      />
    </Card>
  );
}

export { ProjectList };
