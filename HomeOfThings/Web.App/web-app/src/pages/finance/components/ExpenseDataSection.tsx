import React from 'react';

interface IProps {
  sectionId: number;
  selectedSectionId: number;
}

const ExpenseDataSection: React.FC<IProps> = (props) => {
  const { sectionId, selectedSectionId } = props;

  if (sectionId !== selectedSectionId) {
    return null;
  }

  return <div>Data Overview</div>;
};

export default ExpenseDataSection;
