import React from 'react';
import { observer } from 'mobx-react-lite';
import {
	Divider,
	FormControl,
	Grid,
	InputLabel,
	LinearProgress,
	MenuItem,
	Select,
	Typography
} from '@mui/material';
import {
	ArrowUpward as ArrowUpwardIcon,
	ArrowDownward as ArrowDownwardIcon,
} from '@mui/icons-material';

import { VirtualList } from '../../core/components/virtual-list/VirtualList';
import { AppContext } from '../../global/provider';
import { RowRendererProps } from '../../core/components/virtual-list/VirtualListItem';
import { IListConfig, ProjectListViewStore } from './ProjectsListViewStore';
import { IProjectDto } from '../../model/Project';
import { StyledTitleCell } from './styles';
import { cn } from '../../utils/cn';
import AddPopover from '../../core/components/popovers/AddPopover';
import { NewProjectForm } from './detail/forms/NewProjectForm';

const ARROWS = {
	ASC: <ArrowDownwardIcon />,
	DESC: <ArrowUpwardIcon />
};

interface ProjectItemProps {
	item: IProjectDto;
	config: IListConfig;
}
const ProjectListItem = observer(({ item, config }: ProjectItemProps) => {
	const children = config.getValue(item);
	const clickable = React.useMemo(() => typeof config.onClick === 'function', [config.onClick]);

	return (
		<Grid
			item
			style={{ ...config.style, cursor: clickable ? 'pointer' : 'auto' }}
			onClick={clickable ? () => config.onClick!(item) : undefined}
		>
			{children}
		</Grid>
	);
});

function ProjectsListView() {
	const { container } = React.useContext(AppContext);
	const uiStore = React.useMemo(() => new ProjectListViewStore(container), [container]);
	const { listStore, companyListStore, listConfig } = uiStore;
	const items = listStore?.items || [];

	return (
		<section style={{ padding: 16 }}>
			<Grid container justifyContent='space-between'>
				<Grid item>
					<Grid container alignItems='center' spacing={2}>
						<Grid item>
							<Typography variant='h5' children='Filters:' />
						</Grid>
						<Grid item>
							<FormControl fullWidth size='small'>
								<InputLabel id='company-select-label'>Company</InputLabel>
								<Select
									labelId='company-select-label'
									value={listStore.filters.companyId || ''}
									label='Company'
									onChange={uiStore.onChangeCompanyFilter}
									style={{ minWidth: 200 }}
								>
									<MenuItem value={''} key={'none'}>All</MenuItem>
									{companyListStore.items.map(c => (
										<MenuItem value={c.id} key={c.id}>{c.name}</MenuItem>
									))}
								</Select>
							</FormControl>
						</Grid>
					</Grid>
				</Grid>
				<Grid item>
					<AddPopover
						Cmp={NewProjectForm}
						disabled={listStore.isLoading}
						cmpProps={{
							companies: companyListStore.items,
							onSubmit: uiStore.onAddProject
						}}
					/>
				</Grid>
			</Grid>

			<Divider style={{ margin: '32px 0' }} />

			<Grid container alignItems='center' justifyContent='space-between' style={{ borderBottom: '1px solid rgba(0,0,0,0.2)', paddingBottom: 6 }}>
				{listConfig.map(config => (
					<StyledTitleCell item style={config.style} key={config.id}>
						<p>{config.title}</p>
						<div
							className={cn('sort-icon', listStore.sortKey === config.id && 'active')}
							onClick={config.setSortDir}
						>
							{ARROWS[config.getSortDir!()]}
						</div>
					</StyledTitleCell>
				))}
			</Grid>
			{listStore.isLoading && (<div><LinearProgress /></div>)}
			<VirtualList
				list={uiStore?.listStore?.items || []}
				rowRenderer={({ key, index, style }: RowRendererProps) => (
					<div key={key} style={style}>
						<Grid container alignItems='center' justifyContent='space-between' style={{ height: '100%' }}>
							{listConfig.map(config => <ProjectListItem key={config.id} item={items[index]} config={config} />)}
						</Grid>
					</div>
				)}
			/>
		</section>
	);
}

export default observer(ProjectsListView);