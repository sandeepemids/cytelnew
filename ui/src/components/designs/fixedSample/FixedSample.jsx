import React, { Component } from "react";
import { Tabs, Tab } from 'react-bootstrap';
import './fixed-sample.css';
import { AdaptationRules } from "../common/adaptationRules";
import { Objective } from "../common/objective";
import { ExperimentalDesign } from "../common/experimentalDesign";

class FixedSample extends Component {
    constructor(props) {
        super(props);
    }

    componentDidMount = () => {
        // this.getStatisticalEngines();
    }

    componentWillReceiveProps(nextProps) {
    }

    componentWillUnmount = () => {
    }

    render() {

        return (
            <Tabs defaultActiveKey="objective" id="uncontrolled-tab-example">
                <Tab eventKey="objective" title="Objective">
                   <Objective />
                </Tab>
                <Tab eventKey="experimental" title="Experimental Design">
                    <ExperimentalDesign />
                </Tab>
                <Tab eventKey="adaptation" title="Adaptation Rules">
                    <AdaptationRules />
                </Tab>
            </Tabs>
        );
    }
}
export { FixedSample };