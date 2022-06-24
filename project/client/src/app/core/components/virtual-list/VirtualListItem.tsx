import React from 'react';
import { StyledListItem } from './styles';

export interface RowRendererProps {
    key: string;
	index: number;
	isScrolling: boolean;
	isVisible: boolean;
	style: React.CSSProperties;
}

export function VirtualListItem(props: RowRendererProps): JSX.Element {
	const { key, index, style } = props;

	return (
		<StyledListItem key={key} style={style}>
			{index}
		</StyledListItem>       
	);
};