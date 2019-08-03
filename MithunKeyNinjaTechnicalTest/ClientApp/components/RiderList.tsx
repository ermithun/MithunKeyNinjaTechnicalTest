import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link, NavLink, BrowserRouter as Router, Route } from 'react-router-dom';
import { AddRiderData } from './AddRiderData';

interface RiderState {
    riders: Rider[];
    loading: boolean;
}

export class RiderList extends React.Component<RouteComponentProps<{}>, RiderState> {
    constructor(props) {
        super(props);
        this.state = { riders: [], loading: true };
        fetch('api/Rider/List')
            .then(response => response.json() as Promise<Rider[]>)
            .then(data => {
                this.setState({ riders: data, loading: false });
            });

        this.handleDelete = this.handleDelete.bind(this);
        this.handleEdit = this.handleEdit.bind(this);
        this.componentDidUpdate = this.componentDidUpdate.bind(this);
    }

    componentDidUpdate(preProps, preStates) {
        console.log("preprops", preProps);
        console.log("prestates", preStates);
        fetch('api/Rider/List')
            .then(response => response.json() as Promise<Rider[]>)
            .then(data => {
                this.setState({ riders: data, loading: false });
            });
        //console.log(this.props.state.counters);
    }
   

    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderRiderList(this.state.riders);

        return <div>
            <h1>Rider</h1>
            <p>
                <Link to="/addriderdata">Create New</Link>
            </p>
            {contents}
        </div>;
    }

    // Handle Delete request for an rider  
    private handleDelete(id: number) {
        if (!confirm("Do you want to delete rider with Id: " + id))
            return;
        else {
            fetch('api/rider/Delete/?id=' + id, {
                method: 'delete'
            }).then(data => {
                console.log("data deleted successfully");
                //console.log(this.state);
                this.setState(
                    {
                        riders: this.state.riders.filter((rec) => { return (rec.id != id) })
                    });
            });
        }
    }



    private handleEdit(id: number) {
        const { history } = this.props;
        history.push("/rider/Edit/" + id);
    }


    private  renderRiderList(riders: Rider[]) {
        return <table className='table'>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>FIRST NAME</th>
                    <th>LAST NAME</th>
                    <th>PHONE NUMBER</th>
                    <th>EMAIL </th>
                    <th>START DATE</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {riders.map(x =>
                    <tr key={x.id}>
                        <td>{x.id}</td>
                        <td>{x.firstName}</td>
                        <td>{x.lastName}</td>
                        <td>{x.phoneNumber}</td>
                        <td>{x.email}</td>
                        <td>{x.startDate}</td>
                        <td>
                            <a className="action" onClick={(id) => this.handleEdit(x.id)}> Edit </a>
                            <a className="action" onClick={(id) => this.handleDelete(x.id)}> Delete </a>
                        </td>

                    </tr>
                )}
            </tbody>
        </table>;
    }
}

export class Rider {
    id: number = 0;
    firstName: string = "";
    lastName: string = "";
    phoneNumber: string = "";
    email: string = "";
    startDate: string = "";
}
