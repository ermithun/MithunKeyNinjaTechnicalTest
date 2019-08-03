import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Rider } from './RiderList';
import { RouteComponentProps } from 'react-router';


interface AddRiderDataState {
    title: string;
    loading: boolean;
    riderData: Rider;
}

export class AddRiderData extends React.Component<RouteComponentProps<{}>, AddRiderDataState> {
    constructor(props) {
        super(props);
        this.state = { title: "", loading: true, riderData: new Rider };
        var id = this.props.match.params["id"]; 

        // This will set state for Edit rider
        if (id > 0) {
            fetch('api/Rider/Edit/?id=' + id)
                .then(response => response.json() as Promise<Rider>)
                .then(data => {
                    this.setState({ title: "Edit", loading: false, riderData: data });
                });
        }
        // This will set state for Add rider  
        else {
            this.state = { title: "Create", loading: false, riderData: new Rider };
        }

        // This binding is necessary to make "this" work in the callback  
        this.handleSave = this.handleSave.bind(this);
        this.handleCancel = this.handleCancel.bind(this);

    }


    public render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderCreateForm();

        return <div>
            <h1>{this.state.title}</h1>
            <h3>Rider</h3>
            <hr />
            {contents}
        </div>;

    }

    // This will handle the submit form event.  

    private handleSave(event) {
        event.preventDefault();
        const data = new FormData(event.target);
       // const d = new Rider{id = }

        // PUT request for Edit Rider.  
        if (this.state.riderData.id) {
            fetch('api/Rider/Update', {
                method: 'PUT',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/rider");
                })
        }
        // POST request for Add rider.  
        else {
            fetch('api/Rider/Create', {
                method: 'POST',
                body: data,
            }).then((response) => response.json())
                .then((responseJson) => {
                    this.props.history.push("/rider");
                })
        }
    }

    // This will handle Cancel button click event.  

    private handleCancel(e:any) {
        e.preventDefault();
        this.props.history.push("/rider");

    }

    // Returns the HTML Form to the render() method.  

    private renderCreateForm() {
        return (
            <form onSubmit={this.handleSave}>
                <div className="form-group row">
                    <input type="hidden" name="Id" value={this.state.riderData.id} />
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="FirstName">First Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="FirstName" defaultValue={this.state.riderData.firstName} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="LastName">Last Name</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="LastName" defaultValue={this.state.riderData.lastName} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="PhoneNumber">Phone Number</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="PhoneNumber" defaultValue={this.state.riderData.phoneNumber} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="Email">Email</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="Email" defaultValue={this.state.riderData.email} required />
                    </div>
                </div>
                <div className="form-group row">
                    <label className="control-label col-md-12" htmlFor="StartDate">Start Date</label>
                    <div className="col-md-4">
                        <input className="form-control" type="text" name="StartDate" defaultValue={this.state.riderData.startDate} required />
                    </div>
                </div>
                <div className="form-group">
                    <button type="submit" className="btn btn-default">Save</button>
                    <button className="btn" onClick={this.handleCancel}>Cancel</button>
                </div>
            </form>
        )
    }
}