import React from 'react';
import SettingsPageLayout from '../../../components/layouts/SettingsPageLayout';
import { IListItem } from '../../../lib/interfaces/list/IListItem';
import { StyledPaper } from '../../../components/styledComponents/StyledLayout';
import ExpenseDataSection from '../components/ExpenseDataSection';
import ExpenseDataImportSection from '../components/ExpenseDataImportSection';
import { useI18n } from '../../../hooks/useI18n';

const ExpenseOverviewPage: React.FC = () => {
  const [selectedItem, setSelectedItem] = React.useState<number>(0);
  const { getResource } = useI18n();

  const menuItems: IListItem[] = [
    {
      id: 0,
      title: getResource('budget.labelTitleBudgetOverview'),
      subTitle: getResource('budget.labelSubTitleBudgetOverview'),
    },
    {
      id: 1,
      title: getResource('budget.labelTitleAddData'),
      subTitle: getResource('budget.labelSubTitleAddData'),
    },
  ];

  const handleItemClicked = React.useCallback((id: number) => {
    setSelectedItem(id);
  }, []);

  return (
    <SettingsPageLayout
      pageTitle={getResource('budget.labelExpenseDataPage')}
      listItems={menuItems}
      selectedItem={selectedItem}
      handleItemClicked={handleItemClicked}
    >
      <StyledPaper>
        <ExpenseDataSection
          sectionId={0}
          selectedSectionId={selectedItem}
        />
        <ExpenseDataImportSection
          sectionId={1}
          selectedSectionId={selectedItem}
        />
      </StyledPaper>
    </SettingsPageLayout>
  );
};

export default ExpenseOverviewPage;
