import React from "react";
import {
    Button,
    Grid,
    TextField,
    Typography
} from "@mui/material";
import { IProjectDto } from "../../../../model/Project";
import { action, makeObservable, observable } from "mobx";
import { observer } from "mobx-react-lite";

interface NewLogFormProps {
    project: IProjectDto;
    onClose: () => void;
    onSubmit: (amount: number) => void;
}

class NewLogFormStore {
    public hours: number = 0;
    public minutes: number = 0;
    public setUnit(unit: 'hours' | 'minutes', value: number) { this[unit] = value; }

    constructor(private _props: NewLogFormProps) {
        makeObservable(this, {
            hours: observable,
            minutes: observable,
            setUnit: action.bound,
        })
    }

    public onChangeHandler = (ev: React.ChangeEvent<HTMLInputElement>) => {
        const { value, name } = ev.currentTarget;
        const amount = parseInt(value);
        if (isNaN(amount) || !Reflect.has(this, name)) { return; }
        this.setUnit(name as 'hours' | 'minutes', parseInt(value));
    }

    public onSave = () => {
        if (!this.hours && !this.minutes) { return; }
        const { onSubmit, onClose } = this._props;
        onSubmit(this.hours * 60 + this.minutes);
        onClose();
    }
}

export const NewLogForm = observer((props: NewLogFormProps) => {
    const store = React.useMemo(() => new NewLogFormStore(props), [props])

    return (
        <Grid container direction='column' spacing={1}>
            <Grid item>
                <Typography variant='h6' children='Add Log' style={{ paddingBottom: 6, textAlign: 'center' }} />
            </Grid>
            <Grid item>
                <Grid container spacing={1}>
                    <Grid item>
                        <TextField
                            style={{ maxWidth: 120 }}
                            label='Hours'
                            variant='outlined'
                            size='small'
                            type='number'
                            name='hours'
                            value={store.hours}
                            onChange={store.onChangeHandler}
                        />
                    </Grid>
                    <Grid item>
                        <TextField
                            style={{ maxWidth: 120 }}
                            label='Minutes'
                            variant='outlined'
                            size='small'
                            type='number'
                            name='minutes'
                            value={store.minutes}
                            onChange={store.onChangeHandler}
                        />
                    </Grid>
                </Grid>
            </Grid>
            <Grid item>
                <Grid container justifyContent='space-around'>
                    <Button variant='contained' color='info' onClick={props.onClose}>
                        Cancel
                    </Button>
                    <Button
                        variant='contained'
                        color='primary'
                        onClick={store.onSave}
                        disabled={!store.hours && !store.minutes}
                    >
                        Save
                    </Button>
                </Grid>
            </Grid>
        </Grid>
    );
});