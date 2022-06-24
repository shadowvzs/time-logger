
import React from 'react';
import { AutoSizer, List } from 'react-virtualized';
import { StyledList } from './styles';
import { RowRendererProps, VirtualListItem } from './VirtualListItem';

interface VirtualListProps<T extends { id: string}> {
	list: T[];
	containerStyles?: React.CSSProperties;
	rowRenderer?: (props: RowRendererProps) => JSX.Element;
}

export function VirtualList<T extends { id: string }>(props: VirtualListProps<T>) {

	const rowItem = props.rowRenderer || VirtualListItem;
	return (
		<StyledList style={props.containerStyles}>
			<AutoSizer>
				{({ width, height }) => (
					<List
						width={width}
						height={height}
						rowCount={props.list.length}
						rowHeight={40}
						rowRenderer={rowItem}
						getItem={(i: number) => props.list[i]}
					/>
				)}
			</AutoSizer>
		</StyledList>
	);
}