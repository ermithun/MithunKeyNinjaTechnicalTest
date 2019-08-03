import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { RiderList } from './components/RiderList';
import { AddRiderData } from './components/AddRiderData';
import { RiderReviewList } from './components/RiderReview';
 
export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/rider' component={RiderList} />
    <Route path='/addriderdata' component={AddRiderData} />
    <Route path='/rider/edit/:id' exact component={AddRiderData} />
    <Route path='/riderreview' component={RiderReviewList}/>

</Layout>;
