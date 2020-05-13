import React, { Component } from "react";
import  Form from "@rjsf/core";
import { Row,Col } from 'react-bootstrap';
import { customSchemaField } from '../utils/customSchemaField';
import './design-params.css';

class DesignParams extends Component {
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

 
transformErrors=(errors) => {

  return errors.map(error => { 
    if (error.name === "required") {
      if(error.property === '.name')
          error.message = 'Name is a required field'
    }
    return error;
  });
}

 CustomFieldTemplate=(props)=> {
  const {id, classNames, label, help, required, description, errors, children} = props;
  return (
    <Row className="design-params-fields">
       <Col>
       <label htmlFor={id}>{label}{required ?<span className="text-danger">*</span> : null}</label>
      {description}
      {children}
      {errors}
      {help}
      </Col>
      </Row>
  );
}
  onFieldChange = (name, formData) => {
    //Handle individual field change here...
    console.log('Changed Field', name);
}

  render() {
    const designParamsFromContext = {
        onFieldChange: this.onFieldChange
    };
   
    // Please remove the files and these lines after api integration
    const schema = require('./jsonSchema.json');
    const uiSchema =require('./uiSchema.json')
    const formData = require('./formData.json');

    return (
        <Form 
        fields={{ SchemaField: customSchemaField }} 
        formContext={designParamsFromContext}
        schema={schema}
        uiSchema={uiSchema}
        formData={formData}
        FieldTemplate={this.CustomFieldTemplate}
        liveValidate
        transformErrors={this.transformErrors}
        showErrorList={false}
        />
    );
  }
}
export { DesignParams };