
import React from "react";
import SchemaField from '@rjsf/core/lib/components/fields/SchemaField';

export const customSchemaField = function (props) {

    const customProps = {};
  
    //Only process if we are dealing with a field, not the parent object
    if (props.name) {
  
        const formContext = props.registry.formContext;        
        
        //Store the original onChange event provided to the SchemaField
        //as well as the name of the field
        const { onChange, name } = props;
  
        //Provide a new onChange event for the SchemaField
        customProps.onChange = function(formData) {
  
            //Call the custom handler provided in the formContext, if it exists,
            //with the field name and new value
            if (formContext && formContext.onFieldChange && 
                typeof formContext.onFieldChange === 'function') {
  
                formContext.onFieldChange(name, formData);
            }
  
            //Call the original onChange handler
            onChange(formData);
        };
  
    }
  
    return (
        <SchemaField {...props} {...customProps} />
    );
  };