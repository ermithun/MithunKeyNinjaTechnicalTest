import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { RiderList } from './components/RiderList';
import { AddRiderData } from './components/AddRiderData';


export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/counter' component={ Counter } />
    <Route path='/fetchdata' component={FetchData} />
    <Route path='/rider' component={RiderList} />
    <Route path='/addriderdata' component={AddRiderData} />
    <Route path='/rider/edit/:id' exact component={AddRiderData} />  
    

</Layout>;
