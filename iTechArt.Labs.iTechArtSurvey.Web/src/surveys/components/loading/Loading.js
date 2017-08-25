import React from 'react';
import PropTypes from 'prop-types';

const Loading = (props) => (
    props.loading &&
    <div className='d-flex justify-content-center m-5'>
        <i className='fa fa-spinner fa-spin fa-4x'></i>
    </div>
);

Loading.propTypes = {
    loading: PropTypes.bool
};

Loading.defaultProps = {
    loading: true
};
export default Loading;