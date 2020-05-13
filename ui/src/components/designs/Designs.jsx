import React, { Component } from "react";
import { Card } from 'react-bootstrap';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTasks } from "@fortawesome/pro-regular-svg-icons";
import { DesignParams } from './common/designParams';
import { FixedSample } from './fixedSample';
import  './designs.css';

class Designs extends Component {

  constructor(props) {
    super(props);
  }

  componentDidMount = () => {
  }

  componentWillReceiveProps(nextProps) {
  }

  componentWillUnmount = () => {
  }

  render() {
    return (
      <Card >
        <Card.Body>
        <Card.Title className="designs-title">
            <div >
              <FontAwesomeIcon
                id="designsIcon"
                icon={faTasks}
              />   Designs
            </div>
          </Card.Title>
              <DesignParams /> 
              <FixedSample />
          {/*<FixedSample></FixedSample>
          {/* Render FixedSample, Group Sequential, Group Sequential SSR  based on
              dropdown selection from drop down selection in DesignParams component 
              Note: using form onchange event we can identify which element got changed.
          */
          }
        </Card.Body>
      </Card>
    );
  }
}
export { Designs };